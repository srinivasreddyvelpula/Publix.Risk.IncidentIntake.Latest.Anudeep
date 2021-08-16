// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Publix.Risk.IncidentIntake.Domain.Core.Models
{
    public partial class UserDetailsTable
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string PrivsExpire { get; set; }
        public string PasswdExpire { get; set; }
        public string DocPath { get; set; }
        public string SunStart { get; set; }
        public string SunEnd { get; set; }
        public string MonStart { get; set; }
        public string MonEnd { get; set; }
        public string TuesStart { get; set; }
        public string TuesEnd { get; set; }
        public string WedsStart { get; set; }
        public string WedsEnd { get; set; }
        public string ThursStart { get; set; }
        public string ThursEnd { get; set; }
        public string FriStart { get; set; }
        public string FriEnd { get; set; }
        public string SatStart { get; set; }
        public string SatEnd { get; set; }
        public string Checksum { get; set; }
        public string UpdatedByUser { get; set; }
        public string DttmRcdLastUpd { get; set; }
        public int? ForceChangePwd { get; set; }
        public int? IsPwdReset { get; set; }
    }
}
