using Publix.Risk.IncidentIntake.Domain.Features.Code;
using System;


namespace Publix.Risk.IncidentIntake.Domain
{
    public class ClaimEntity
    {
        private DateTime dttmOfClaim;

        public int ClaimId { get; set; }
        public string? ClaimNumber { get; set; }
        public int TypeCode { get; set; }
        public int EventId { get; set; }
        public virtual EventEntity? Event { get; set; }
        public CodeEntity? ClaimStatusCode { get; set; }
        public CodeEntity? LineOfBusCode { get; set; }
        public virtual PersonInvolved? PrimaryPIEmployee { get; set; }

        public DateTime DateOfClaim
        {
            get
            {
                return dttmOfClaim.Date;
            }
            set
            {
                dttmOfClaim = new DateTime(value.Year, value.Month, value.Day, dttmOfClaim.Hour, dttmOfClaim.Minute, dttmOfClaim.Second);
            }
        }

        public DateTime TimeOfClaim
        {
            get
            {
                return dttmOfClaim.ToLocalTime();
            }
            set
            {
                dttmOfClaim = new DateTime(dttmOfClaim.Year, dttmOfClaim.Month, dttmOfClaim.Day, value.Hour, value.Minute, value.Second);
            }
        }

        public bool OpenFlag { get; set; }
        public CodeEntity? ClaimTypeCode { get; set; }
        public DateTime? DateReported { get; set; }
        public string? AddedBy { get; set; }
    }
}
