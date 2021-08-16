using Microsoft.EntityFrameworkCore;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Features.Associate;
using Publix.Risk.IncidentIntake.Domain.Features.Code;
using Publix.Risk.IncidentIntake.Domain.Features.Entity;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.Model.ValueObjects;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Publix.Risk.IncidentIntake.Persistence.Repository.Context
{
    public partial class RMXContext : DbContext, IRMXContext
    {
        private List<int> ORG_ENTITY_IDS = new List<int>()
        {
            1005,       // CLIENT
            1006,       // Company
            1007,       // Operation
            1008,       // Region
            1009,       // Division
            1010,       // Location
            1011,       // Facility
            1012        // Departmnt
        };

        public RMXContext()
        { }


        public RMXContext(DbContextOptions<RMXContext> options)
            : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }


        public DbSet<EntityEntity> Entities { get; set; }
        public DbSet<AssociateEntity> Associates { get; set; }
        public DbSet<CodeEntity> Codes { get; set; }
        public DbSet<Glossary> Glossary { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<FolderEntity> Folders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DRMXD01;Initial Catalog=Riskmaster;Integrated Security=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FolderEntity>(entity =>
            {
                entity.HasKey(e => new { e.UserId });

                entity.ToTable("DOC_FOLDERS", "dbo");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .IsRequired();

                entity.Property(e => e.FolderId)
                    .HasColumnName("FOLDER_ID");

                entity.Property(e => e.FolderName)
                .HasColumnName("FOLDER_NAME")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId)
                    .HasColumnName("PARENT_ID");

                entity.Property(e => e.FolderPath)
                    .HasColumnName("FOLDER_PATH")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.TableName)
                    .HasColumnName("TABLE_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RecordId)
                    .HasColumnName("RECORD_ID");
            });

            modelBuilder.Entity<EntityEntity>(entity =>
        {
            entity.HasKey(e => new { e.EntityId });

            entity.ToTable("ENTITY", "dbo");

            entity.Property(e => e.EntityId)
                .HasColumnName("ENTITY_ID");

            entity.Property(e => e.Abbreviation)
                .HasColumnName("ABBREVIATION")
                .HasMaxLength(25)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.GlossaryId)
                .HasColumnName("ENTITY_TABLE_ID")
                .IsRequired(false);

            entity.Property(e => e.Addr1)
                .HasColumnName("ADDR1")
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.Addr2)
                .HasColumnName("ADDR2")
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.AlsoKnownAs)
                .HasColumnName("ALSO_KNOWN_AS")
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .HasColumnName("CITY")
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.CountryId)
                .IsRequired(false)
                .HasColumnName("COUNTRY_CODE");

            entity.Property(e => e.Deleted)
                .HasColumnName("DELETED_FLAG")
                .HasColumnType("smallint")
                .HasConversion<int?>(
                   b => (b.GetValueOrDefault(false) ? 5611 : 5610),
                   i => i.GetValueOrDefault(5610) == 5611);

            entity.Property(e => e.EmailAddress)
                .HasColumnName("EMAIL_ADDRESS")
                .IsRequired(false)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FirstName)
                .HasColumnName("FIRST_NAME")
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.TaxId)
                .HasColumnName("TAX_ID")
                .HasMaxLength(20)
                .IsRequired(false)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .HasColumnName("LAST_NAME")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.MiddleName)
                .HasColumnName("MIDDLE_NAME")
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ParentId)
                .IsRequired(false)
                .HasColumnName("PARENT_EID");

            entity.Property(e => e.StateId)
                .IsRequired(false)
                .HasColumnName("STATE_ID");

            entity.Property(e => e.Title)
                .HasColumnName("TITLE")
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ZipCode)
                .HasColumnName("ZIP_CODE")
                .IsRequired(false)
                .HasMaxLength(10);

            entity.Property(e => e.SexId)
                .IsRequired(false)
                .HasColumnName("SEX_CODE");

            entity.Property(e => e.Created)
                .HasColumnName("DTTM_RCD_ADDED")
                .HasMaxLength(14)
                .HasConversion<string?>(
                    d => d.HasValue ? d.Value.ToString("yyyyMMddHHmmss") : null,
                    s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s.PadRight(14, '0'), "yyyyMMddHHmmss", null));

            entity.Property(e => e.CreatedBy)
                .HasColumnName("ADDED_BY_USER")
                .IsRequired(false)
                .HasMaxLength(50);

            entity.Property(e => e.LastUpdated)
                .HasColumnName("DTTM_RCD_LAST_UPD")
                .HasMaxLength(14)
                .HasConversion<string?>(
                    d => d.HasValue ? d.Value.ToString("yyyyMMddHHmmss") : null,
                    s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s.PadRight(14, '0'), "yyyyMMddHHmmss", null));

            entity.Property(e => e.LastUpdatedBy)
                .HasColumnName("UPDATED_BY_USER")
                .IsRequired(false)
                .HasMaxLength(50);

            entity.Property(e => e.BirthDate)
                .HasColumnName("BIRTH_DATE")
                .HasMaxLength(14)
                .HasConversion<string?>(
                    d => d.HasValue ? d.Value.ToString("yyyyMMddHHmmss") : null,
                    s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s.PadRight(14, '0'), "yyyyMMddHHmmss", null));

        });

            modelBuilder.Entity<State>(s =>
            {
                s.HasKey(e => new { e.StateId });

                s.ToTable("STATES", "dbo");

                s.Property(e => e.StateId)
                    .HasColumnName("STATE_ROW_ID");

                s.Property(e => e.Abbreviation)
                 .HasColumnName("STATE_ID")
                 .HasMaxLength(3)
                 .IsUnicode(false);

                s.Property(e => e.Name)
                .HasColumnName("STATE_NAME");
            });

            modelBuilder.Entity<Glossary>(t =>
            {
                t.HasKey(e => new { e.GlossaryId });

                t.ToTable("GLOSSARY", "dbo");

                t.Property(e => e.GlossaryId)
                 .HasColumnName("TABLE_ID")
                 .IsRequired();

                t.Property(e => e.TableName)
                 .HasColumnName("SYSTEM_TABLE_NAME")
                 .HasMaxLength(30)
                 .IsUnicode(false);

                t.Property(e => e.NextId)
                .HasColumnName("NEXT_UNIQUE_ID");

                t.Property(e => e.Deleted)
                 .HasColumnName("DELETED_FLAG")
                 .HasColumnType("smallint")
                 .HasConversion<int?>(
                    b => (b.GetValueOrDefault(false) ? 5611 : 5610),
                    i => i.GetValueOrDefault(5610) == 5611);
            });

            modelBuilder.Entity<AssociateEntity>(entity =>
            {
                entity.HasKey(e => e.EntityId);

                entity.ToTable("EMPLOYEE", "dbo");

                entity.HasIndex(e => e.EntityId)
                    .HasName("EMPLOYEE_EID")
                    .IsUnique();

                entity.Property(e => e.EntityId)
                    .HasColumnName("EMPLOYEE_EID");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DEPT_ASSIGNED_EID");

                entity.Property(e => e.HireDate)
                    .HasColumnName("DATE_HIRED")
                    .IsRequired(false)
                    .HasMaxLength(8)
                    .HasConversion(
                        d => d.HasValue ? d.Value.ToString("yyyyMMdd") : null,
                        s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s, "yyyyMMdd", null));

                entity.Property(e => e.PERNR)
                    .HasColumnName("EMPLOYEE_NUMBER")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsRequired(true);

                entity.Property(e => e.FullTime)
                    .HasColumnName("FULL_TIME_FLAG")
                    .HasColumnType("smallint")
                    .HasConversion<int?>(
                       b => (b ? 5611 : 5610),
                       i => i.GetValueOrDefault(5610) == 5611);
            });

            modelBuilder.Entity<CodeTextEntity>(entity =>
            {
                entity.HasKey(e => new { e.CodeTextId });

                entity.ToTable("CODES_TEXT", "dbo");

                entity.Property(e => e.CodeTextId)
                    .HasColumnName("CODE_ID");

                entity.Property(e => e.Description)
                    .HasColumnName("CODE_DESC")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CodeEntity>(entity =>
            {
                entity.HasKey(e => new { e.CodeId });

                entity.ToTable("CODES", "dbo");

                entity.Property(e => e.CodeId)
                    .HasColumnName("CODE_ID");

                entity.Ignore(e => e.CodeTextId)
                    .UsePropertyAccessMode(PropertyAccessMode.Property);

                entity.Property(e => e.ShortCode)
                    .HasColumnName("SHORT_CODE")
                    .HasMaxLength(25)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.GlossaryId)
                    .HasColumnName("TABLE_ID").IsRequired();

                entity.Property(e => e.StartDate)
                    .HasColumnName("EFF_START_DATE")
                    .HasColumnType("varchar(8)")
                    .HasConversion<string?>(
                        d => d.HasValue ? d.Value.ToString("yyyyMMdd") : null,
                        s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s.Substring(0, 8), "yyyyMMdd", null)
                    );

                entity.Property(e => e.EndDate)
                    .HasColumnName("EFF_END_DATE")
                    .HasColumnType("varchar(8)")
                    .HasConversion<string?>(
                        d => d.HasValue ? d.Value.ToString("yyyyMMdd") : null,
                        s => string.IsNullOrEmpty(s) ? new DateTime?() : DateTime.ParseExact(s.Substring(0, 8), "yyyyMMdd", null)
                    );

                entity.Property(e => e.Deleted)
                    .HasColumnName("DELETED_FLAG")
                    .HasColumnType("smallint")
                    .HasConversion<int?>(
                       b => (b ? 5611 : 5610),
                       i => i.GetValueOrDefault(5610) == 5611);
            });

            modelBuilder.Entity<CodeEntity>().HasOne(e => e.Glossary).WithOne().IsRequired();
            modelBuilder.Entity<CodeEntity>().HasOne(e => e.CodeText).WithOne()
                .HasForeignKey<CodeTextEntity>(t => t.CodeTextId)
                .IsRequired();

            modelBuilder.Entity<AssociateEntity>().HasOne(a => a.Entity).WithOne().IsRequired();
            modelBuilder.Entity<AssociateEntity>().HasOne(e => e.Department).WithOne();

            modelBuilder.Entity<EntityEntity>().HasOne(e => e.Glossary).WithOne().IsRequired();
            modelBuilder.Entity<EntityEntity>().HasOne(e => e.State).WithOne();
            modelBuilder.Entity<EntityEntity>().HasOne(e => e.Country).WithOne();
            modelBuilder.Entity<EntityEntity>().HasOne(e => e.Sex).WithOne();
            modelBuilder.Entity<EntityEntity>().HasOne(e => e.Parent).WithOne();

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public IEnumerable<CodeEntity>? CodeByType(CodeType type)
        {
            try
            {
                IEnumerable<CodeEntity> results = this.Codes.Where(c => c.GlossaryId == type.TableId && !c.Deleted)
                    .Include(c => c.CodeText)
                    .Include(c => c.Glossary)
                    .AsNoTracking()
                    .ToList();

                results = results.Where(c => (c.StartDate ?? DateTime.Now.AddDays(-1)) <= DateTime.Now &&
                                (c.EndDate ?? DateTime.Now.AddDays(1)) >= DateTime.Now);

                if (type.ListType == "Simple")
                {
                    return results.OrderBy(c => c.CodeText.Description);
                }
                else
                {
                    return null;    //we only use this method to return simple lists
                }
            }
            catch (Exception ex)
            {
                string sql = this.Codes.Where(c => c.GlossaryId == type.TableId && !c.Deleted)
                    .Include(c => c.CodeText)
                    .Include(c => c.Glossary)
                    .ToSql();

                System.Diagnostics.Debug.WriteLine(sql);
                throw;
            }
        }


        public int? GetNextTableID(string tableName)
        {
            var results = this.Glossary.Where(g => g.TableName.ToUpper() == tableName.ToUpper());

            if (results.Any())
            {
                if (results.Count() == 1)
                {
                    return results.First().NextId;
                }

                else
                {
                    // Not sure what to do in this case.  Return first record for now
                    return results.First().NextId;
                }
            }

            return null;
        }

        public IEnumerable<CodeEntity>? EntityCodesByType(CodeType type)
        {
            if (type.ListType != "Hierarchical")
            {
                return null;
            }

            try
            {
                IEnumerable<EntityEntity> list;
                if (type.TableId == 0)
                {
                    list = this.Entities.Where(c => c.GlossaryId != null && ORG_ENTITY_IDS.Contains(c.GlossaryId.Value) && (!c.Deleted ?? false))
                        .Include(c => c.Glossary)
                        .Include(c => c.Parent)
                        .AsNoTracking()
                        .ToList();
                }
                else
                {
                    list = this.Entities.Where(c => c.GlossaryId != null && type.TableId == c.GlossaryId.Value && (!c.Deleted ?? false))
                        .Include(c => c.Glossary)
                        .Include(c => c.Parent)
                        .AsNoTracking()
                        .ToList();
                }

                IEnumerable<CodeEntity> results = list.Where(e => e.GlossaryId != null).OrderBy(e => e.GlossaryId).ThenBy(e => e.Parent.AlsoKnownAs ?? e.Parent.LastName).ThenBy(e => e.AlsoKnownAs ?? e.LastName).Select(e =>
                {
                    string? name = string.IsNullOrEmpty(e.AlsoKnownAs) ? e.LastName : e.AlsoKnownAs;
                    return new CodeEntity(e.EntityId, e.ParentId?.ToString(), new CodeTextEntity(e.EntityId, name), e.GlossaryId.Value, e.Glossary, null, null, e.Deleted ?? false);
                });

                return results;//.OrderBy(c => c.CodeText.Description);
            }
            catch (Exception ex)
            {
                string sql = this.Entities.Where(e => (!e.Deleted ?? false) && e.GlossaryId != null).OrderBy(e => e.GlossaryId).OrderBy(e => e.Parent.AlsoKnownAs ?? e.Parent.LastName).OrderBy(e => e.AlsoKnownAs ?? e.LastName)
                    .Include(c => c.Glossary)
                    .Include(c => c.Parent)
                    .ToSql();

                System.Diagnostics.Debug.WriteLine(sql);
                throw;
            }
        }
    }
}
