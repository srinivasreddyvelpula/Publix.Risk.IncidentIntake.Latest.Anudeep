using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Model.ValueObjects;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;

namespace Publix.Risk.IncidentIntake.Domain.Features.Entity
{
    public class EntityEntity : Address
    {
        public EntityEntity()
        {
            EntityId = 0;
            Glossary = new Glossary();
            AlsoKnownAs = "";
            LastName = "";
            Addr1 = "";
            City = "";
            ZipCode = "";
            CreatedBy = "";
            LastUpdatedBy = "";
        }


        public EntityEntity(string? abbreviation, int glossaryId, Glossary glossary, string? title, string? firstName, string? middleName, string lastName,
            string aka, string addr1, string? addr2, string city, int? stateId, State? state, int? countryId, CodeEntity? country, string zip, string? email,
            int? parentEID, EntityEntity? parent, bool? deleted, int? sexId, CodeEntity? sex, DateTime created, string createdBy, DateTime updated, string updatedBy) :
            this(0, abbreviation, glossaryId, glossary, title, firstName, middleName, lastName, aka, addr1, addr2, city, stateId, state, countryId, country, zip,
                email, parentEID, parent, deleted, sexId, sex, created, createdBy, updated, updatedBy)
        {
        }


        public EntityEntity(int entityId, string? abbreviation, int glossaryId, Glossary glossary, string? title, string? firstName, string? middleName, string lastName,
            string aka, string addr1, string? addr2, string city, int? stateId, State? state, int? countryId, CodeEntity? country, string zip, string? email,
            int? parentEID, EntityEntity? parent, bool? deleted, int? sexId, CodeEntity? sex, DateTime created, string createdBy, DateTime updated, string updatedBy)
        {
            this.EntityId = entityId;
            this.Abbreviation = abbreviation;
            GlossaryId = glossaryId;
            Glossary = glossary;
            Title = title;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            AlsoKnownAs = aka;
            Addr1 = addr1;
            Addr2 = addr2;
            City = city;
            StateId = stateId;
            State = state;
            CountryId = countryId;
            Country = country;
            ZipCode = zip;
            EmailAddress = email;
            ParentId = parentEID;
            Parent = parent;
            Deleted = deleted;
            SexId = sexId;
            Sex = sex;
            Created = created;
            CreatedBy = createdBy;
            LastUpdated = updated;
            LastUpdatedBy = updatedBy;
        }


        public int EntityId { get; set; }

        public string? Abbreviation { get; set; }

        public int? GlossaryId { get; set; }
        public virtual Glossary? Glossary { get; set; }

        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? AlsoKnownAs { get; set; }
        public string? EmailAddress { get; set; }

        public int? ParentId { get; set; }
        public EntityEntity? Parent { get; set; }

        public bool? Deleted { get; set; }

        public int? SexId { get; set; }
        public virtual CodeEntity? Sex { get; set; }

        public DateTime? Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? TaxId { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
