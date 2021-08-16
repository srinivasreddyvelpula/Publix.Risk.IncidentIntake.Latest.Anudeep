namespace Publix.Risk.IncidentIntake.Domain
{
    public class FolderEntity
    {
        public string? TableName { get; set; }
        public int FolderId { get; set; }
        public int? ParentId { get; set; }
        public string? FolderName { get; set; }
        public string? FolderPath { get; set; }
        public int UserId { get; set; }
        public int RecordId { get; set; }
    }
}
