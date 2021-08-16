using Publix.Risk.IncidentIntake.Domain.Model.ValueObjects;
using System;


namespace Publix.Risk.IncidentIntake.Domain.Features.Code
{
    public class CodeEntity
    {
        public CodeEntity()
        {
            CodeId = 0;
            ShortCode = string.Empty;
            CodeText = null;
            GlossaryId = null;
            Glossary = null;
            StartDate = null;
            EndDate = null;
            Deleted = false;
        }


        public CodeEntity(int codeId, string? shortCode, CodeTextEntity text, int glossaryId, Glossary? glossary, DateTime? startDate, DateTime? endDate, bool deleted)
        {
            CodeId = codeId;
            ShortCode = shortCode;
            CodeText = text;
            GlossaryId = glossaryId;
            Glossary = glossary;
            StartDate = startDate;
            EndDate = endDate;
            Deleted = deleted;
        }


        public int CodeId { get; private set; }

        public string? ShortCode { get; private set; }

        public int CodeTextId
        {
            get
            {
                return CodeId;
            }
            set
            {
                //do nothing
            }
        }

        public virtual CodeTextEntity? CodeText { get; private set; }

        public int? GlossaryId { get; private set; }

        public virtual Glossary? Glossary { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public bool Deleted { get; private set; }
    }
}
