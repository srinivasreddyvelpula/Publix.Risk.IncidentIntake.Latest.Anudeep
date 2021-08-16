using System;


namespace Publix.Risk.IncidentIntake.Domain.Core.Model
{
    public class API_Login
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid Token { get; set; }
    }
}
