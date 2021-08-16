
using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Model.ValueObjects;

namespace Publix.Risk.IncidentIntake.Domain.ValueObjects
{
    public class Address
    {
        public string Addr1 { get; set; }
        public string? Addr2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public int? CountryId { get; set; }
        public string? County { get; set; }
        public CodeEntity? Country { get; set; }
        public string? ZipCode { get; set; }
    }
}