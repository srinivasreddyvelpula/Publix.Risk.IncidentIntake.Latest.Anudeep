using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Features.Entity
{
    public class GetEntityQuery : IQuery<GetEntityResult>
    {
        public int EntityId { get; set; }


        public GetEntityQuery(int entityId)
        {
            EntityId = entityId;
        }
    }


    public class GetEntityResult
    {
        public GetEntityResult(EntityEntity? entity)
        {
            if (entity == null)
            {
                return;
            }

            Entity = entity;
        }

        public EntityEntity Entity { get; }
    }


    public class GetEntityQueryHandler : IQueryHandler<GetEntityQuery, GetEntityResult>
    {
        private ILogger Logger { get; }
        private IRMXContext dbContext { get; }


        public GetEntityQueryHandler(ILogger logger, IRMXContext context)
        {
            Logger = logger;
            dbContext = context;
        }


        public async Task<GetEntityResult> Handle(GetEntityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetEntityResult result = new GetEntityResult(await GetEntity(request.EntityId));

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "", request);
                throw;
            }
        }


        private async Task<EntityEntity> GetEntity(int entityId)
        {
            EntityEntity entity = dbContext.Entities.Where(e => e.EntityId == entityId)
                                        .AsNoTracking()
                                        .Include(e => e.State)
                                        .Include(e => e.Country)
                                        .Include(e => e.Glossary)
                                        .Include(e => e.Sex)
                                        .SingleOrDefault();

            return await Task.FromResult(entity);
        }
    }

}
