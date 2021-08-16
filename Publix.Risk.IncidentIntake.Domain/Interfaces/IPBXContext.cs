using Microsoft.EntityFrameworkCore;
using Publix.Risk.IncidentIntake.Domain.Model;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Interfaces
{
    public interface IPBXContext
    {
        DbSet<LogEntry> Logs { get; set; }


        Task<int> SaveChanges();
    }
}