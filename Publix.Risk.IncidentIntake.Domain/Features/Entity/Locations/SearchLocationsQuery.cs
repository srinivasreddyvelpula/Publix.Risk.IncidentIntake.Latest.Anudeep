using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Publix.Risk.IncidentIntake.Domain.Features.Entity
{
    public class SearchLocationsQuery : IQuery<SearchLocationsResult>
    {
        public string? Number { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


        public SearchLocationsQuery(string? number, string? city, string? state, int page = 1, int pageSize = -1)
        {
            Number = number;
            City = city;
            State = state;
            Page = page;
            PageSize = pageSize;
        }
    }


    public class SearchLocationsResult : SearchEntitysResult
    { }


    public class SearchLocationsQueryHandler : IQueryHandler<SearchLocationsQuery, SearchLocationsResult>
    {
        private ILogger Logger { get; }
        private int DefaultMaxPageSize { get; }
        private IRMXContext dbContext { get; }


        public SearchLocationsQueryHandler(ILogger logger, IConfiguration config, IRMXContext context)
        {
            Logger = logger;
            DefaultMaxPageSize = int.Parse(config["MaxPageSize"] ?? "50");
            dbContext = context;
        }


        public async Task<SearchLocationsResult> Handle(SearchLocationsQuery request, CancellationToken cancellationToken)
        {
            if (request.PageSize < 0)
            {
                request.PageSize = DefaultMaxPageSize;
            }

            SearchLocationsResult result = new SearchLocationsResult
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Results = await SearchLocations(request)
            };

            return await Task.FromResult(result);

        }


        private async Task<List<EntityEntity>> SearchLocations(SearchLocationsQuery request)
        {
            try
            {
                string num = request.Number.FixWildcards();
                string c = request.City.FixWildcards();
                string st = request.State.FixWildcards();

                var query = dbContext.Entities.Where(e => e.GlossaryId == 1010 &&
                                                    e.LastName.Contains(num) &&
                                                    e.City.Contains(c) &&
                                                    (e.State.Abbreviation.Equals(st) || e.State.Name.Contains(st)))
                                            .AsNoTracking()
                                            .Include(e => e.State)
                                            .Include(e => e.Country)
                                            .Include(e => e.Glossary)
                                            .Include(e => e.Parent)
                                            .Skip((request.Page - 1) * request.PageSize)
                                            .Take(request.PageSize);

                return await Task.FromResult(query.ToList());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, request);
                return await Task.FromResult(new List<EntityEntity>());
            }
        }
    }

}
