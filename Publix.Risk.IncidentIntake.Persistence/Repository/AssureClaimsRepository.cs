using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Features.Incident;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.Metadata;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using Publix.Risk.IncidentIntake.Persistence.AssureClaims;
using Publix.Risk.IncidentIntake.Persistence.AssureClaims.OpenAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;



namespace Publix.Risk.IncidentIntake.Persistence.Repository
{
    public class AssureClaimsRepository : IAssureClaimsRepository
    {
        private IRMXContext RMXContext { get; }
        private ILogger Logger { get; }
        private v2Client Client { get; }
        private string Authorization { get; }

        public AssureClaimsRepository(ILogger logger, IConfiguration config, IRMXContext context, IHttpClientFactory factory)
        {
            Logger = logger;
            RMXContext = context;
            Client = new v2Client(factory, config);
            Authorization = config["API_Key"];
        }

        public async Task<CreateEntityResult> CreateEntity(CreateEntityCommand request)
        {
            var entityType = EntityType.GetAll().FirstOrDefault(et => et.Value == request.TypeCodeId);
            if (!entityType.CanBeCreated)
            {
                //verify the entity type is allowed to be created
                throw new NotSupportedException("This entity type is not allowed to be created via Incident Intake.");
            }

            Logger.LogDebug($"About to create entity", new EntityMetadata(0, $"{request.FirstName} {request.LastName}", request.Abbreviation)); //default new entity id = 0

            Entity entity = BuildEntity(request);
            var result = await Client.CreateEntitiesAsync(Authorization, entity);

            return new CreateEntityResult()
            {
                Entity = ConvertViewModelEntity(result.viewModel)
            };
        }

        public async Task<CreateIncidentResult?> CreateEvent(CreateIncidentCommand request)
        {
            try
            {
                Logger.LogDebug("Starting Create Incident Handler request.", new IncidentMetadata(JsonConvert.SerializeObject(request)));

                Event? evt = BuildEvent(request);
                var result = new CreateIncidentResult();
                if (evt != null)
                {
                    var response = await Client.CreateEventAsync(Authorization, evt);

                    Event newEvt = ConvertViewModelToEvent(response.viewModel);

                    Logger.LogInformation("Event created.", new EventMetadata(newEvt.EventNumber, newEvt.EventId.GetValueOrDefault(), newEvt.EventDescription, newEvt.DateOfEvent, newEvt.RptdByEid?.Id?.ToString()));

                    EventEntity? evtEntity = ConvertEvent(newEvt);

                    if (evtEntity != null)
                    {
                        result.EventId = evtEntity.EventId;
                        result.ClaimId = null;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error Creating Event", ex, new IncidentMetadata(request));
                throw;
            }
        }

        public async Task<bool> UpdateClaim(ClaimEntity updatedClaim)
        {
            Logger.LogDebug($"About to update claim {updatedClaim.ClaimNumber}", new ClaimMetadata(updatedClaim));

            Claim claim = ConvertClaimToModel(updatedClaim);
            var result = await Client.SaveClaimAsync(Authorization, claim, updatedClaim.EventId.ToString(), updatedClaim.ClaimId.ToString());

            if (result != null && result.claimId == updatedClaim.ClaimId)
            {
                return true;
            }

            Logger.LogError($"Server failed to respond to API call: (POST) 'events'", new ClaimMetadata(updatedClaim));

            return false;
        }

        public async Task AttachDocumentToEvent(EventEntity @event, string serverFilename)
        {
            DocumentForm attachment = new DocumentForm()
            {
                AttachRecordId = @event.EventId,
                AttachTable = "EVENT",
                Subject = "Incident Intake Form",
                Title = serverFilename,
                FolderId = GetEventFolderId(serverFilename).ToString(),
                Notes = $"Reported by {@event.ReportedBy.FirstName} {@event.ReportedBy.LastName}"
            };
            Logger.LogDebug($"About to attach document '{serverFilename}' to event", new EventMetadata(@event));

            await Client.CreateAttachmentAsEventv2Async(Authorization, attachment, @event.EventId.ToString());
        }

        public async Task<ClaimEntity?> GetClaim(int eventId, int claimId)
        {
            Logger.LogDebug($"About to get claim {claimId}", null);

            bool orig = Client.ReadResponseAsString;

            // since this method is sole used for testing API calls, lets use text reading for debug purposes.
            Client.ReadResponseAsString = true;
            var claim = await Client.GetClaimAsync(Authorization, eventId, claimId);

            if (claim == null)
            {
                Logger.LogError($"Server failed to respond to API call: 'claims/{claimId}'", null);
            }

            Client.ReadResponseAsString = orig;

            return ConvertClaim(claim);
        }

        public async Task<int> AddNewClaim(EventEntity @event, CreateIncidentCommand request, int initialClaimstatusId)
        {
            Codes status = GetCodes(initialClaimstatusId);
            Claim newClaim = BuildClaim(@event, request, status);

            //newClaim.EstCollection = @event.EventId;
            //newClaim.EventNumber = @event.EventNumber;
            //newClaim.DateRptdToRm = DateTime.Now.ToString("d");
            IList<FluentValidation.Results.ValidationFailure> errors = new List<FluentValidation.Results.ValidationFailure>();

            string jsonClaim = JsonConvert.SerializeObject(newClaim);
            Logger.LogDebug($"About to create claim on event {@event.EventNumber}", new ClaimMetadata(newClaim.ClaimId.GetValueOrDefault(), newClaim.ClaimNumber));

            var result = await Client.CreateClaimAsync(Authorization, newClaim, @event.EventId.ToString());

            if (result != null)
            {
                return result.viewModel.claimId;
            }
            else
            {
                Logger.LogError($"Server failed to respond to API call: (POST) 'events/{@event.EventId}/claims'", new ClaimMetadata(newClaim.ClaimId.GetValueOrDefault(), newClaim.ClaimNumber));
            }

            return 0;
        }

        public Task<EventEntity> GetEvent(int? eventId)
        {
            throw new NotImplementedException();
        }

        #region Private Methods
        private ClaimEntity? ConvertClaim(Claim? claim)
        {
            if (claim == null)
            {
                return null;
            }

            ClaimEntity entity = new ClaimEntity();

            entity.ClaimId = claim.ClaimId.GetValueOrDefault();
            entity.ClaimNumber = claim.ClaimNumber;
            entity.ClaimStatusCode = RMXContext.Codes.Single(c => c.CodeId == claim.ClaimStatusCode.Id);
            entity.ClaimTypeCode = RMXContext.Codes.Single(c => c.CodeId == claim.ClaimTypeCode.Id);
            entity.DateOfClaim = DateTime.Parse(claim.DateOfClaim);
            entity.DateReported = DateTime.Parse(claim.DateRptdToRm);
            entity.EventId = claim.EventId.GetValueOrDefault();
            entity.LineOfBusCode = RMXContext.Codes.Single(c => c.CodeId == claim.LineOfBusCode.Id);
            entity.OpenFlag = claim.OpenFlag ?? true;
            entity.PrimaryPIEmployee = ConvertPI(claim.PrimaryPiEmployee);
            entity.TimeOfClaim = DateTime.ParseExact(claim.TimeOfClaim, "hhmmss", null);
            entity.TypeCode = claim.ClaimTypeCode.Id.GetValueOrDefault();

            return entity;
        }

        private PersonInvolved? ConvertPI(PiEmployee? primaryPiEmployee)
        {
            if (primaryPiEmployee == null)
            {
                return null;
            }

            PersonInvolved pi = new PersonInvolved();

            pi.Entity = RMXContext.Entities.FirstOrDefault(e => e.EntityId == primaryPiEmployee.PiEid.Id);
            pi.PI_Id = primaryPiEmployee.PiRowId.GetValueOrDefault();
            pi.PERNR = primaryPiEmployee.EmployeeNumber;

            return pi;
        }

        private int GetEventFolderId(string serverFilename)
        {
            int id = 0;

            // map server filename path to a known folder to get its ID
            string? path = Path.GetFullPath(serverFilename);
            string? folder = Path.GetDirectoryName(serverFilename);

            if (!string.IsNullOrEmpty(path))
            {
                // look in DB for folders to find this one or return null
                var folders = RMXContext.Folders.Where(f => f.FolderPath == path || f.FolderName == folder).FirstOrDefault();

                if (folders != null)
                {
                    id = folders.FolderId;
                }
            }

            return id;
        }

        private EventEntity? ConvertEvent(Event viewModel)
        {
            EventEntity e = new EventEntity();

            e.EventId = viewModel.EventId.GetValueOrDefault();
            e.EventNumber = viewModel.EventNumber;

            e.Addr1 = viewModel.Addr1;
            e.Addr2 = viewModel.Addr2;
            e.City = viewModel.City;

            e.Country = RMXContext.Codes.Single(c => c.CodeId == viewModel.CountryCode.Id);
            e.EventDate = DateTime.ParseExact(viewModel.DateOfEvent, "yyyyMMdd", null);
            e.ReportedAt = DateTime.ParseExact(viewModel.DateReported, "yyyyMMdd", null);
            e.ReportedBy = ConvertEntity(viewModel.ReporterEntity);

            e.DepartmentId = viewModel.DeptEid.Id;
            e.Department = RMXContext.Entities.Single(e => e.EntityId == viewModel.DeptEid.Id);
            e.Description = viewModel.EventDescription;
            e.EventType = EventType.FromValue(viewModel.EventTypeCode.Id.GetValueOrDefault());
            e.State = RMXContext.States.Single(s => s.StateId == viewModel.StateId.Id);
            e.StatusCode = StatusType.FromValue(viewModel.EventStatusCode.Id.GetValueOrDefault());
            e.ZipCode = viewModel.ZipCode;

            return e;
        }

        private EntityEntity ConvertEntity(Entity rpt)
        {
            return new EntityEntity()
            {
                Abbreviation = rpt.Abbreviation,
                Addr1 = rpt.Addr1,
                Addr2 = rpt.Addr2,
                AlsoKnownAs = rpt.AlsoKnownAs,
                City = rpt.City,
                Country = RMXContext.Codes.Single(c => c.CodeId == rpt.CountryCode.Id),
                Created = DateTime.Parse(rpt.EffectiveDate),
                CreatedBy = rpt.RmUserId.FirstOrDefault()?.Name,
                Deleted = rpt.DeletedFlag,
                GlossaryId = int.Parse(rpt.EntityTableId),
                Glossary = RMXContext.Glossary.Single(g => g.GlossaryId.ToString() == rpt.EntityTableId),
                LastUpdated = DateTime.Parse(rpt.DttmRcdLastUpd),
                LastUpdatedBy = null,
                Parent = RMXContext.Entities.FirstOrDefault(e => e.EntityId == rpt.ParentEid.Id),
                Sex = RMXContext.Codes.Single(s => s.CodeId == rpt.SexCode.Id),
                State = RMXContext.States.Single(s => s.StateId == rpt.StateId.Id),
                EmailAddress = rpt.EmailAddress,
                EntityId = rpt.EntityId.GetValueOrDefault(),
                FirstName = rpt.FirstName,
                LastName = rpt.LastName,
                MiddleName = rpt.MiddleName,
                Title = rpt.Title,
                ZipCode = rpt.ZipCode,
                BirthDate = DateTime.Parse(rpt.BirthDate),
                TaxId = rpt.TaxId,
                Phone1 = rpt.Phone1,
                Phone2 = rpt.Phone2
            };
        }

        private EntityEntity? ConvertViewModelEntity(EntityViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            return new EntityEntity()
            {
                Abbreviation = viewModel.abbreviation,
                Addr1 = viewModel.addr1,
                Addr2 = viewModel.addr2,
                AlsoKnownAs = viewModel.alsoKnownAs,
                BirthDate = DateTime.Parse(viewModel.birthDate),
                City = viewModel.city,
                Country = RMXContext.Codes.Single(s => s.CodeId == viewModel.countryCode.id),
                Deleted = viewModel.deletedFlag,
                LastUpdated = DateTime.Parse(viewModel.dttmRcdLastUpd.ToString()),
                EmailAddress = viewModel.emailAddress,
                EntityId = viewModel.entityId,
                FirstName = viewModel.firstName,
                LastName = viewModel.lastName,
                MiddleName = viewModel.middleName,
                Parent = RMXContext.Entities.Single(e => e.EntityId == viewModel.parentEid.id),
                Phone1 = viewModel.phone1,
                Phone2 = viewModel.phone2,
                Sex = RMXContext.Codes.Single(s => s.CodeId == viewModel.sexCode.id),
                State = RMXContext.States.Single(s => s.StateId == viewModel.stateId.id),
                TaxId = viewModel.taxId,
                Title = viewModel.title,
                ZipCode = viewModel.zipCode,
                Created = DateTime.Parse(viewModel.effectiveDate),
                CreatedBy = viewModel.rmUserId.FirstOrDefault()?.name,
                GlossaryId = viewModel.entityTableId,
                Glossary = RMXContext.Glossary.Single(g => g.GlossaryId == viewModel.entityTableId),
                LastUpdatedBy = null,
            };
        }

        private Claim BuildClaim(EventEntity evt, CreateIncidentCommand newIncident, Codes status)
        {
            Claim model = new Claim();

            model.ClaimId = 0;
            model.ClaimNumber = "";
            model.ClaimStatusCode = status;
            model.ClaimTypeCode = GetClaimTypeCode(evt, newIncident);
            model.DateOfClaim = evt.EventDate.ToString("yyyyMMdd");
            model.DateRptdToRm = evt.ReportedAt?.ToString("yyyyMMdd") ?? DateTime.Now.ToString("yyyyMMdd");
            model.EventId = evt.EventId;
            //model.LineOfBusCode = GetLOBCode(newIncident.LOB);
            model.OpenFlag = status.ShortCode == "O";
            model.TimeOfClaim = model.TimeOfClaim;
            model.PrimaryPiEmployee = BuildPIEmployee(evt, newIncident, model.ClaimTypeCode);

            List<SupplementalField> supps = new List<SupplementalField>();
            // TODO: Add Claim supplemental fields here
            model.Supplementals = supps.ToArray();

            return model;
        }

        private PiEmployee? BuildPIEmployee(EventEntity evt, CreateIncidentCommand newIncident, Codes claimType)
        {
            if (claimType.ShortCode != "WC")
                return null;

            // capture data coming from UI to send to API
            List<int> employeeRelatedEventTypes = new List<int>() { 2316, 2315, 460250, 505 };
            if (employeeRelatedEventTypes.Contains(evt.EventType.Value))
            {
                PiEmployee emp = new PiEmployee();

                emp.ActiveFlag = true;

                var associate = RMXContext.Associates.Where(a => a.EntityId == newIncident.associateInjury.EmployeeEId).FirstOrDefault();
                if (associate == null)
                {
                    throw new ApplicationException($"Unknown Associate with Entity ID: {newIncident.associateInjury.EmployeeEId}");
                }
                emp.EmployeeNumber = associate.PERNR;

                emp.ActivityWhenInjured = GetCodes(newIncident.associateInjury.ActivityEngagedId).Desc;
                emp.BodyParts = newIncident.associateInjury.InjuredAssociate.BodyPartIds.Select(b =>
                {
                    return new Codes()
                    { Id = b };
                }).ToList();

                emp.InjuryCodes = newIncident.associateInjury.InjuredAssociate.InjuryIds.Select(b =>
                {
                    return new Codes()
                    { Id = b };
                }).ToList();

                emp.DateHired = associate.HireDate?.ToString("yyyyMMdd");
                emp.DeptAssignedEid = new Codes() { Id = associate.DepartmentId };
                emp.PiEntity = new Entity() { EntityId = associate.EntityId };
                emp.PiRowId = null;
                emp.EventId = evt.EventId;
                emp.FacilityDeptEid = new Codes() { Id = associate.DepartmentId };
                emp.FullTimeFlag = associate.FullTime;
                emp.PiEid = new Lookups() { Id = associate.EntityId };
                if (associate.Entity.ParentId != newIncident.MgrEId)
                {
                    Logger.LogInformation("Associate's Parent Entity is not equal to the passed in Manager ID", associate.EntityId, newIncident.MgrEId);
                }
                emp.SupervisorEid = new Lookups() { Id = newIncident.MgrEId };
                emp.WeeklyHours = newIncident.associateInjury.InjuredAssociate.AvgWeeklyHours;
                emp.EstRtwDate = newIncident.associateInjury.InjuredAssociate.DateReturnedToWork;
                emp.InjuryCauseCode = new Codes() { Id = newIncident.associateInjury.InjuredAssociate.CauseOfInjuryId };
                emp.DateOfDeath = newIncident.associateInjury.InjuredAssociate.Fatality ?? false ? DateTime.Now.ToString("yyyyMMdd") : "";
                emp.WorkdayStartTime = newIncident.associateInjury.InjuredAssociate.ShiftStartTime;
                emp.HourlyRate = newIncident.associateInjury.InjuredAssociate.HourlyRate;

                List<SupplementalField> supps = new List<SupplementalField>();
                supps.Add(new SupplementalField() { FieldName = "P_TYP_INVLV_CODE", Value = InvolvementType.InjuredAssociate.Value });
                supps.Add(new SupplementalField() { FieldName = "P_EMP_LNG_CODE", Value = newIncident.associateInjury.InjuredAssociate.PrimaryLanguageId }); // TODO: convert to code value
                supps.Add(new SupplementalField() { FieldName = "P_EMP_WRKDY_NUM", Value = newIncident.associateInjury.InjuredAssociate.WorkDays });
                //supps.Add(new SupplementalField() { FieldName = "P_PER_MINOR_CODE", Value = associate.Entity.Minor });  // TODO: convert to code value
                //supps.Add(new SupplementalField() { FieldName = "P_MIN_GAURD_TEXT", Value = associate.Entity.GaurdiansName });
                //supps.Add(new SupplementalField() { FieldName = "P_PER_SPOUS_TEXT", Value = associate.Entity.SpousesName });
                supps.Add(new SupplementalField() { FieldName = "P_PSN_ISVDR_CODE", Value = newIncident.associateInjury.VendorInvolved }); // TODO: convert to code value
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });
                supps.Add(new SupplementalField() { FieldName = "", Value = "" });

                emp.Supplementals = supps.ToArray();

                return emp;
            }

            return null;
        }

        private Codes GetLOBCode(int lobID)
        {
            LOBCodes? lob = LOBCodes.FromValue(lobID);

            if (lob != null)
            {
                return new Codes()
                {
                    CodeTable = "LINE_OF_BUS",
                    Id = lob.Value,
                    ShortCode = lob.Description
                };
            }
            else
            {
                return new Codes();
            }
        }

        private Codes GetClaimTypeCode(EventEntity evt, CreateIncidentCommand request)
        {
            int id = 0;
            string shortCode = "";

            switch (evt.EventType.Value)
            {
                case 2315:
                    id = 240;
                    shortCode = "AU";
                    break;

                case 460250:
                    id = 244;
                    shortCode = "FL";
                    break;

                case 505:
                    id = 243;
                    shortCode = "QR";
                    break;

                case 2320:
                    id = 254;
                    shortCode = "PD";
                    break;

                case 2317:
                case 2321:
                    id = 242;
                    shortCode = "GC";
                    break;

                case 2521:
                    id = 246;
                    shortCode = "CQA";
                    break;

                default:    // Workers Comp
                    id = 241;
                    shortCode = "WC";
                    break;
            }

            return new Codes()
            {
                CodeTable = "CLAIM_TYPE",
                Id = id,
                ShortCode = shortCode
            };
        }

        private Event BuildEvent(CreateIncidentCommand incident)
        {
            // Major portion of application logic resides here.  This method converts the data sent from the UI into
            // an Event Model object that we can then send to the Assure Claims API to create the event in the DB
            Event model = new Event();

            model.EventId = 0;
            model.EventNumber = GetNextEventNumber();

            model.DateOfEvent = incident.DateOfEvent;
            model.DateReported = incident.DateReported;
            model.DeptEid = GetCodes(incident.DepartmentEId);
            model.EventDescription = incident.EventDescription;
            model.EventStatusCode = GetCodes(incident.StatusCodeId);
            model.EventTypeCode = GetCodes(incident.EventTypeId);
            model.RptdByEid = new Lookups() { Id = incident.ReportedByEId, Desc = "Reported_By" };
            model.TimeOfEvent = incident.TimeOfEvent;
            model.TimeReported = incident.TimeReported;

            EntityEntity location = RMXContext.Entities.Where(e => e.EntityId == incident.LocationEId.GetValueOrDefault()).FirstOrDefault();
            if (location != null)
            {
                model.Addr1 = location.Addr1;
                model.Addr2 = location.Addr2;
                model.City = location.City;
                model.StateId = new Codes() { Id = location.StateId ?? 11 }; // default to Florida
                model.ZipCode = location.ZipCode;
                model.LocationAreaDesc = location.AlsoKnownAs;
                model.LocationTypeCode = new Codes() { Id = location.GlossaryId ?? 0 };
            }

            //model.CauseCode = GetCodes(incident.CauseCodeId);
            model.OnPremiseFlag = incident.OnPremiseFlag;

            List<SupplementalField> supps = new List<SupplementalField>();
            // TODO: add event supplemental fields here
            model.Supplementals = supps.ToArray();

            return model;
        }

        private int GetNextEntityId()
        {
            int max = RMXContext.Glossary.Where(g => g.TableName == "ENTITY").First().NextId ?? 1;

            return max;
        }

        private string GetNextEventNumber()
        {
            int max = RMXContext.Glossary.Where(g => g.TableName == "EVENT").First().NextId ?? 1;

            string number = $"EV{DateTime.Now.Year}{max.ToString().PadLeft(6, '0')}";

            return number;
        }

        private Codes GetCodes(int? code)
        {
            if (code == null)
            {
                code = 0;
            }

            var entity = RMXContext.Codes.Where(c => c.CodeId == code).FirstOrDefault();

            return new Codes() { Id = entity.CodeId, ShortCode = entity.ShortCode, CodeTable = entity.Glossary.TableName, Desc = entity.CodeText.Description };
        }

        private Entity BuildEntity(CreateEntityCommand request)
        {
            Entity entity = new Entity();

            entity.Abbreviation = request.Abbreviation;
            entity.Addr1 = request.Addr1;
            entity.Addr2 = request.Addr2;
            entity.AlsoKnownAs = request.AlsoKnownAs;
            entity.City = request.City;
            entity.CountryCode = GetCodes(request.CountryId);
            entity.EntityId = GetNextEntityId();
            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            entity.ParentEid = new Lookups() { Id = request.ParentEId.GetValueOrDefault() };
            entity.Phone1 = request.Phone1;
            entity.Phone2 = request.Phone2;
            entity.StateId = GetCodes(request.StateId);
            entity.ZipCode = request.ZipCode;
            entity.EntityTableId = request.TypeCodeId.ToString();
            entity.TaxId = request.TaxId;

            return entity;
        }

        private Event ConvertViewModelToEvent(EventViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            Event evt = new Event();

            evt.AccountId = viewModel.accountId;
            evt.Addr1 = viewModel.addr1;
            evt.Addr2 = viewModel.addr2;
            evt.BriefDesc = viewModel.briefDesc;
            evt.CatastropheNumber = GetCodes(viewModel.catastropheNumber.id);
            evt.CauseCode = GetCodes(viewModel.causeCode.id);
            evt.City = viewModel.city;
            evt.CountryCode = GetCodes(viewModel.countryCode.id);
            evt.DateOfEvent = viewModel.dateOfEvent;
            evt.DateReported = viewModel.dateReported;
            evt.DeptEid = GetCodes(viewModel.deptEid.id);
            evt.DttmRcdLastUpd = viewModel.dttmRcdLastUpd;
            evt.EventDescription = viewModel.eventDescription;
            evt.EventDescription_HTMLComments = viewModel.eventDescription_HTMLComments;
            evt.EventId = viewModel.eventId;
            evt.EventNumber = viewModel.eventNumber;
            evt.EventStatusCode = GetCodes(viewModel.eventStatusCode.id);
            evt.EventTypeCode = GetCodes(viewModel.eventTypeCode.id);
            evt.OnPremiseFlag = viewModel.onPremiseFlag;
            evt.RptdByEid = new Lookups() { Id = viewModel.rptdByEid.id };
            evt.StateId = GetCodes(viewModel.stateId.id);
            evt.TimeOfEvent = viewModel.timeOfEvent;
            evt.TimeReported = viewModel.timeReported;
            evt.ZipCode = viewModel.zipCode;

            foreach (var supp1 in viewModel.supplementals)
            {
                SupplementalField field = new SupplementalField()
                {
                    Caption = supp1.caption,
                    FieldName = supp1.fieldName,
                    FieldType = (SupplementalFieldFieldType)Enum.Parse(typeof(SupplementalFieldFieldType), supp1.fieldType, true),
                    Value = supp1.value,
                    Values = supp1.values
                };

                evt.Supplementals.Add(field);
            }

            return evt;
        }

        private Claim ConvertClaimToModel(ClaimEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            Claim claim = new Claim();

            claim.ClaimId = entity.ClaimId;
            claim.ClaimNumber = entity.ClaimNumber;
            claim.ClaimStatusCode = GetCodes(entity.ClaimStatusCode.CodeId);
            claim.ClaimTypeCode = GetCodes(entity.ClaimTypeCode.CodeId);
            claim.DateOfClaim = entity.DateOfClaim.ToString("yyyyMMdd");
            claim.DateRptdToRm = entity.DateReported?.ToString("yyyyMMdd") ?? DateTime.Now.ToString("yyyyMMdd");
            claim.EventId = entity.EventId;
            claim.LineOfBusCode = GetCodes(entity.LineOfBusCode.CodeId);
            claim.OpenFlag = entity.OpenFlag;
            claim.PrimaryPiEmployee = ConvertPIToEmployee(entity.PrimaryPIEmployee);
            claim.TimeOfClaim = entity.TimeOfClaim.ToString("hhmmss");

            return claim;
        }

        private PiEmployee? ConvertPIToEmployee(PersonInvolved? pi)
        {
            if (pi == null)
            {
                return null;
            }

            PiEmployee emp = new PiEmployee();

            emp.PiEntity = ConvertEntityEntity(pi.Entity);
            emp.EmployeeNumber = pi.PERNR;
            emp.PiRowId = pi.PI_Id;

            return emp;
        }

        private Entity? ConvertEntityEntity(EntityEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            Entity model = new Entity();

            model.Abbreviation = entity.Abbreviation;
            model.Addr1 = entity.Addr1;
            model.Addr2 = entity.Addr2;
            model.AlsoKnownAs = entity.AlsoKnownAs;
            model.City = entity.City;
            model.CountryCode = GetCodes(entity.CountryId);
            model.EntityId = entity.EntityId;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.MiddleName = entity.MiddleName;
            model.ParentEid = new Lookups() { Id = entity.ParentId.GetValueOrDefault() };
            model.Phone1 = entity.Phone1;
            model.Phone2 = entity.Phone2;
            model.StateId = GetCodes(entity.StateId);
            model.ZipCode = entity.ZipCode;
            model.EntityTableId = entity.Glossary.GlossaryId.ToString();
            model.TaxId = entity.TaxId;

            return model;
        }
        #endregion
    }
}
