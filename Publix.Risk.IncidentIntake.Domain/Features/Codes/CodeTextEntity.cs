namespace Publix.Risk.IncidentIntake.Domain.Features.Code
{
    public class CodeTextEntity
    {
        public CodeTextEntity()
        {

        }


        public CodeTextEntity(int id, string? desc)
        {
            CodeTextId = id;
            Description = desc;
        }

        public int CodeTextId { get; set; }

        public string? Description { get; set; }
    }
}
