using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Features.Entity
{
    public class GetLocationQuery : IQuery<GetLocationResult>
    {
        public int EntityId { get; set; }


        public GetLocationQuery(int entityId)
        {
            EntityId = entityId;
        }
    }


    public class GetLocationResult
    {
        public GetLocationResult(EntityEntity? entity)
        {
            if (entity == null)
            {
                return;
            }

            Entity = entity;
        }

        public EntityEntity Entity { get; }
    }


    public class GetLocationQueryHandler : IQueryHandler<GetLocationQuery, GetLocationResult>
    {
        private ILogger Logger { get; }
        private IRMXContext dbContext { get; }


        public GetLocationQueryHandler(ILogger logger, IRMXContext context)
        {
            Logger = logger;
            dbContext = context;
        }


        public async Task<GetLocationResult> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetLocationResult result = new GetLocationResult(await GetLocation(request.EntityId));

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, request);
                throw;
            }
        }


        private async Task<EntityEntity> GetLocation(int entityId)
        {
            EntityEntity entity = dbContext.Entities.Where(e => e.EntityId == entityId)
                                        .AsNoTracking()
                                        .Include(e => e.State)
                                        .Include(e => e.Country)
                                        .Include(e => e.Glossary)
                                        .Include(e => e.Parent)
                                        .SingleOrDefault();

            return await Task.FromResult(entity);
        }
    }

}
