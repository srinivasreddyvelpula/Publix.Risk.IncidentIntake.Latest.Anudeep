using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Associate
{
    public class GetAssociateQuery : IQuery<GetAssociateResult>
    {
        public string PERNR { get; set; }


        public GetAssociateQuery(string? pernr)
        {
            if (string.IsNullOrEmpty(pernr))
            {
                throw new ArgumentNullException("PERNR");
            }

            PERNR = pernr;
        }
    }


    public class GetAssociateResult
    {
        public GetAssociateResult(AssociateEntity associate)
        {
            Associate = associate;
        }

        public AssociateEntity Associate { get; set; }
    }


    public class GetAssociateQueryHandler : IQueryHandler<GetAssociateQuery, GetAssociateResult>
    {
        private ILogger Logger { get; }
        private IRMXContext dbContext { get; }


        public GetAssociateQueryHandler(ILogger logger, IRMXContext context)
        {
            Logger = logger;
            dbContext = context;
        }


        public async Task<GetAssociateResult> Handle(GetAssociateQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetAssociateResult result = new GetAssociateResult(await GetAssociate(request.PERNR));

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unable to Get Associate.", request);
                throw;
            }
        }


        private async Task<AssociateEntity> GetAssociate(string pernr)
        {
            string other = pernr;
            if (!Char.IsDigit(pernr.ToCharArray()[0]))
            {
                other = "0" + pernr.Substring(1);
            }

            return await Task.Run(() => dbContext.Associates
                    .AsNoTracking()
                     .Include(a => a.Entity)
                        .ThenInclude(d => d.Glossary)
                    .Include(a => a.Entity)
                        .ThenInclude(e => e.Sex)
                    .Include(a => a.Department)
                    .Include(a => a.Entity)
                    .ThenInclude(e => e.Country)
                    .Include(a => a.Entity)
                        .ThenInclude(e => e.State)
                    .SingleOrDefault(e => e.PERNR.ToUpper() == pernr.ToUpper() || e.PERNR == other));
        }
    }
}
