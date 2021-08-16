// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Publix.Risk.IncidentIntake.Domain.Core.Models
{
    public partial class UserTable
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateAbbr { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddr { get; set; }
        public int? ManagerId { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Title { get; set; }
        public string Checksum { get; set; }
        public string CompanyName { get; set; }
        public string UpdatedByUser { get; set; }
        public string DttmRcdLastUpd { get; set; }
        public bool AccountLockStatus { get; set; }
        public short? IsSmsUser { get; set; }
        public string DttmAccountLock { get; set; }
        public short? IsUsrpvgAccess { get; set; }
    }
}
