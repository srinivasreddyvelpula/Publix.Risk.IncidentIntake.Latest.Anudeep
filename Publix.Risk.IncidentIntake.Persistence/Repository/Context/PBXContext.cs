using Microsoft.EntityFrameworkCore;
using Publix.Risk.IncidentIntake.Domain;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Persistence.Repository.Context
{
    public partial class PBXContext : DbContext, IPBXContext
    {
        public PBXContext()
        { }


        public PBXContext(DbContextOptions<PBXContext> options)
            : base(options)
        {
        }


        public async new Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }


        public DbSet<LogEntry> Logs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DRMXD01;Initial Catalog=S0RMXPBX;Integrated Security=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogEntry>(entity =>
            {
                entity.HasKey(e => e.Log_ID);

                entity.ToTable("Log_t", "dbo");

                entity.HasIndex(e => e.Log_ID)
                    .HasName("Log_ID")
                    .IsUnique();

                entity.Property(e => e.Log_ID)
                    .HasColumnName("Log_ID")
                    .UseIdentityColumn();

                entity.Property(e => e.Level)
                    .HasConversion(
                        l => l.Description,
                        d => new LogLevels(d)
                    );

                entity.Property(e => e.AppName)
                    .HasColumnName("AppDomain_Name")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Caller)
                    .HasColumnName("Process_Name")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .HasColumnName("FormattedMessage_Text")
                    .IsUnicode(false);

                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID");

                entity.Property(e => e.Severity)
                    .HasColumnName("Severity_Value")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.MachineName)
                    .HasColumnName("Machine_Name")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasColumnName("Message_text")
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasColumnName("Priority_Value");

                entity.Property(e => e.ProcessId)
                    .HasColumnName("Process_ID")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("Log_Timestamp");

                entity.Property(e => e.ThreadName)
                    .HasColumnName("Thread_Name")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Win32ThreadId)
                    .HasColumnName("Win32Thread_ID")
                    .HasMaxLength(128)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
