using System.Collections.Generic;

namespace Publix.Risk.IncidentIntake.UI.Models
{
    public class CodeTypeModel
    {
        public CodeText codeText { get; set; }
    }
    public class CodeText
    {
        public int codeTextId { get; set; }
        public string description { get; set; }
    }
    public class Codes
    {
        public List<CodeTypeModel> codes { get; set; }
    }
}
