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
    public class SearchEntitysQuery : IQuery<SearchEntitysResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Abbreviation { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


        public SearchEntitysQuery(string? first, string? last, string? abbrev, string? city, string? state, int page = 1, int pageSize = -1)
        {
            FirstName = first;
            LastName = last;
            Abbreviation = abbrev;
            City = city;
            State = state;
            Page = page;
            PageSize = pageSize;
        }
    }


    public class SearchEntitysResult
    {
        public SearchEntitysResult()
        {
            this.Results = new List<EntityEntity>();
        }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int Count => Results.Count();
        public IEnumerable<EntityEntity> Results { get; set; }
    }


    public class SearchEntitysQueryHandler : IQueryHandler<SearchEntitysQuery, SearchEntitysResult>
    {
        private ILogger Logger { get; }
        private int DefaultMaxPageSize { get; }
        private IRMXContext dbContext { get; }


        public SearchEntitysQueryHandler(ILogger logger, IConfiguration config, IRMXContext context)
        {
            Logger = logger;
            DefaultMaxPageSize = int.Parse(config["MaxPageSize"] ?? "50");
            dbContext = context;
        }


        public async Task<SearchEntitysResult> Handle(SearchEntitysQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.PageSize < 0)
                {
                    request.PageSize = DefaultMaxPageSize;
                }

                SearchEntitysResult result = new SearchEntitysResult
                {
                    Page = request.Page,
                    PageSize = request.PageSize,
                    Results = await SearchEntities(request)
                };

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, null, request);
                throw;
            }
        }


        private async Task<IEnumerable<EntityEntity>> SearchEntities(SearchEntitysQuery request)
        {
            string first = request.FirstName.FixWildcards();
            string last = request.LastName.FixWildcards();
            string abbrev = request.Abbreviation.FixWildcards();
            string c = request.City.FixWildcards();
            string st = request.State.FixWildcards();

            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last) &&
                string.IsNullOrEmpty(abbrev) && string.IsNullOrEmpty(c) &&
                string.IsNullOrEmpty(st))
            {
                throw new ArgumentNullException("At least one parameter is required.");
            }

            var query = dbContext.Entities.Where(e => e.FirstName.Contains(first) &&
                                                e.LastName.Contains(last) &&
                                                e.City.Contains(c) &&
                                                e.Abbreviation.Contains(abbrev) &&
                                                ((e.State != null && (e.State.Abbreviation.Equals(st) || e.State.Name.Contains(st))) ||
                                                e.State == null))
                                        .AsNoTracking()
                                        .Include(e => e.State)
                                        .Include(e => e.Country)
                                        .Include(e => e.Sex)
                                        .Skip((request.Page - 1) * request.PageSize)
                                        .Take(request.PageSize);

            return await Task.FromResult(query.ToList());
        }
    }

}
