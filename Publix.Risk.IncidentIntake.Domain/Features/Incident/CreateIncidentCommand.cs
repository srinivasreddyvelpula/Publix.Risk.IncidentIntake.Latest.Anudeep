using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.Metadata;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Incident
{
    public class CreateIncidentCommand : IRequest<CreateIncidentResult>
    {
        public int EventTypeId { get; set; }
        public string? DateOfEvent { get; set; } = DateTime.Now.ToString("yyyyMMdd");
        public string? DateReported { get; set; } = DateTime.Now.ToString("yyyyMMdd");
        public string? EventDescription { get; set; }
        public int ReportedByEId { get; set; }
        public string? TimeOfEvent { get; set; } = DateTime.Now.ToString("hhmmss");
        public string? TimeReported { get; set; } = DateTime.Now.ToString("hhmmss");
        public int? LocationEId { get; set; }
        public bool? OnPremiseFlag { get; set; }
        public int? DepartmentEId { get; set; }
        public int? StatusCodeId { get; set; }
        public bool? CoveredVideo { get; set; }
        public string? CameraDetail { get; set; }
        public bool? PhotosTaken { get; set; }
        public int IncidentTypeId { get; set; }
        public int StateId { get; set; }
        public int? ClaimLOB { get; set; }
        public int? MgrEId { get; set; }
        public string? MgrPERNR { get; set; }
        public bool? CustomerSigned { get; set; }
        public int CostCenterId { get; set; }

        public AssociateInjuryIncident? associateInjury { get; set; }
        public AutoSafetyIncident? autoSafety { get; set; }
        public CartDamageIncident? cartDamage { get; set; }
        public CQAIncident? cQA { get; set; }
        public CustomerInjuryIncident? customerInjury { get; set; }
        public FleetIncident? fleet { get; set; }
        public PropertyDamageIncident? propertyDamage { get; set; }
        public QREIncident? qRE { get; set; }
    }

    public class CreateIncidentResult
    {
        public int? EventId { get; set; }
        public int? ClaimId { get; set; }
    }

    public class CreateIncidentCommandValidator : AbstractValidator<CreateIncidentCommand>
    {
        public CreateIncidentCommandValidator()
        {
            this.RuleFor(p => p.StateId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.IncidentTypeId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.EventTypeId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.EventDescription)
                .NotNull()
                .NotEmpty();

            this.RuleFor(p => p.ReportedByEId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.StatusCodeId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.CostCenterId)
                .NotNull()
                .GreaterThan(0);

            this.RuleFor(p => p.DateOfEvent)
                .NotNull()
                .NotEmpty()
                .Length(8);

            this.RuleFor(p => p.TimeOfEvent)
                .NotNull()
                .NotEmpty()
                .Length(6);

            this.RuleFor(p => p.DateReported)
                .NotNull()
                .NotEmpty()
                .Length(8);

            this.RuleFor(p => p.TimeReported)
                .NotNull()
                .NotEmpty()
                .Length(6);

            this.RuleFor(p => p)
                .Custom((p, context) =>
                {
                    EventType? evtType = EventType.FromValue(p.EventTypeId);

                    if (evtType != null)
                    {
                        if (p.associateInjury != null && evtType == EventType.WorkersCompensation)
                        {
                            this.RuleFor(s => p.associateInjury).SetValidator(new AssocInjuryValidator());
                        }
                        else if (p.autoSafety != null && evtType == EventType.AutoCDL)
                        {
                            this.RuleFor(s => p.autoSafety).SetValidator(new AutoSafetyValidator());
                        }
                        else if (p.cartDamage != null && evtType == EventType.CartDamage)
                        {
                            this.RuleFor(s => p.cartDamage).SetValidator(new CartDamageValidator());
                        }
                        else if (p.cQA != null && evtType == EventType.CQA)
                        {
                            this.RuleFor(s => p.cQA).SetValidator(new CQAValidator());
                        }
                        else if (p.customerInjury != null && evtType == EventType.CustomerIncident)
                        {
                            this.RuleFor(s => p.customerInjury).SetValidator(new CustInjuryValidator());
                        }
                        else if (p.fleet != null && evtType == EventType.AutoNoCDL)
                        {
                            this.RuleFor(s => p.fleet).SetValidator(new FleetSafetyValidator());
                        }
                        else if (p.propertyDamage != null && evtType == EventType.PropertyDamage)
                        {
                            this.RuleFor(s => p.propertyDamage).SetValidator(new PropDamageValidator());
                        }
                        else if (p.qRE != null && evtType == EventType.QRE)
                        {
                            this.RuleFor(s => p.qRE).SetValidator(new QREValidator());
                        }
                        else
                        {
                            context.AddFailure("No matching event data was found for the Event Type provided.");
                        }
                    }
                    else
                    {
                        context.AddFailure("Unknown Event Type provided");
                    }
                });
        }

        public override ValidationResult Validate(ValidationContext<CreateIncidentCommand> context)
        {
            if (context.InstanceToValidate != null)
            {
                return base.Validate(context);
            }

            return new ValidationResult(new List<ValidationFailure>() { new ValidationFailure("instance", "Cannot be null.") });
        }
    }

    public class CreateIncidentCommandHandler : IRequestHandler<CreateIncidentCommand, CreateIncidentResult>
    {
        private ILogger Logger { get; }

        private IAssureClaimsRepository Repo { get; }
        private IPDFService PdfService { get; set; }


        public CreateIncidentCommandHandler(ILogger logger, IAssureClaimsRepository repo, IPDFService service)
        {
            Logger = logger;
            Repo = repo;
            PdfService = service;
        }


        public async Task<CreateIncidentResult> Handle(CreateIncidentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                int? eventId = null;
                int? claimId = null;

                var validator = new CreateIncidentCommandValidator();
                var results = validator.Validate(request);
                if (results.IsValid)
                {
                    Logger.LogDebug("Starting Create Incident Handler request.", new IncidentMetadata(JsonConvert.SerializeObject(request)));

                    var result = await Repo.CreateEvent(request);

                    if (result != null)
                    {
                        eventId = result.EventId;
                        EventEntity? evt = await Repo.GetEvent(eventId);
                        if (evt != null)
                        {
                            Logger.LogInformation("Event created.", new EventMetadata(evt));

                            if (EventNeedsClaim(evt.EventType, out CodeEntity claimStatus))
                            {
                                Logger.LogInformation("Creating claim...", null);
                                claimId = await Repo.AddNewClaim(evt, request, claimStatus.CodeId);
                                result.ClaimId = claimId;
                                Logger.LogInformation("Claim created.", new ClaimMetadata(claimId ?? 0, null));
                            }

                            await PdfService.GenerateAndAttachPDF(evt, request);
                            return result;
                        }
                        else
                        {
                            throw new InvalidOperationException($"CreateEvent call did not return null but no event was returned");
                        }
                    }

                    return new CreateIncidentResult() { EventId = eventId, ClaimId = claimId };
                }
                else
                {
                    throw results.Errors.ToException();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Create Incident Failed", new IncidentMetadata(JsonConvert.SerializeObject(request)));
                throw;
            }
        }

        private bool EventNeedsClaim(EventType evtType, out CodeEntity initalStatus)
        {
            /*
            public static readonly EventType WorkersCompensation = new EventType(2316, "WC");
            public static readonly EventType AutoCDL = new EventType(2315, "AU");
            public static readonly EventType AutoNoCDL = new EventType(460250, "AUNCDL");
            public static readonly EventType QRE = new EventType(505, "QRE");
            public static readonly EventType CustomerIncident = new EventType(2317, "CI");
            public static readonly EventType PropertyDamage = new EventType(2320, "PD");
            public static readonly EventType CartDamage = new EventType(2321, "CD");
            public static readonly EventType WCPrivacy = new EventType(189384, "WCP");
            public static readonly EventType CIPrivacy = new EventType(204959, "ZCIP");
            */
            switch (evtType.Value)
            {
                case 505:
                    initalStatus = new CodeEntity(11, "C", new CodeTextEntity(11, "Closed"), 0, null, null, null, false);   //close
                    return true;

                case 2316:
                    initalStatus = new CodeEntity(10, "O", new CodeTextEntity(10, "Open"), 0, null, null, null, false);   //close
                    return true;

                default:
                    initalStatus = new CodeEntity(11, "C", new CodeTextEntity(11, "Closed"), 0, null, null, null, false);   //close
                    return false;
            }
        }
    }
}
