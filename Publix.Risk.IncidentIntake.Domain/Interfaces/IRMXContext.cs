using Microsoft.EntityFrameworkCore;
using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Model.ValueObjects;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System.Collections.Generic;


namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IRMXContext
    {
        DbSet<EntityEntity> Entities { get; set; }
        DbSet<AssociateEntity> Associates { get; set; }
        DbSet<CodeEntity> Codes { get; set; }
        DbSet<Glossary> Glossary { get; set; }
        DbSet<State> States { get; set; }
        DbSet<FolderEntity> Folders { get; set; }
        IEnumerable<CodeEntity>? EntityCodesByType(CodeType codeType);

        IEnumerable<CodeEntity>? CodeByType(CodeType type);

        int? GetNextTableID(string tableName);
    }
}