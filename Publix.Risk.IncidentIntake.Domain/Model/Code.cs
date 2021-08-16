
using System;

namespace Publix.Risk.IncidentIntake.Domain.Core.Model
{
    public class Code
    {
        public int CodeId { get; set; }

        public string ShortCode { get; set; }

        public virtual CodeText CodeText { get; set; }

        public int GlossaryId { get; set; }

        public virtual Glossary Glossary { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool Deleted { get; set; }
    }
}
