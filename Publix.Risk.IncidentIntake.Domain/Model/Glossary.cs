namespace Publix.Risk.IncidentIntake.Domain.Core.Model
{
    public class Glossary
    {
        public int GlossaryId { get; set; }
        public string TableName { get; set; }
        public int? NextId { get; set; }
        public bool? Deleted { get; set; }
    }
}
