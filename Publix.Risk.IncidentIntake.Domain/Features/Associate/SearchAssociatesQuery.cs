using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Associate
{
    public class SearchAssociatesQuery : IQuery<SearchAssociatesResult>
    {
        public string? PERNR { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? CostCenter { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }


        public SearchAssociatesQuery(string? pernr, string? firstName, string? lastName, string? costCenter, int page = 1, int pageSize = 100)
        {
            PERNR = pernr;
            FirstName = firstName;
            LastName = lastName;
            CostCenter = costCenter;
            Page = page;
            PageSize = pageSize;
        }
    }


    public class SearchAssociatesResult
    {
        public SearchAssociatesResult()
        {
            Results = new List<SearchResult>();
        }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int Count => Results.Count();
        public IEnumerable<SearchResult> Results { get; set; }

        public class SearchResult
        {
            public SearchResult(AssociateEntity associate)
            {
                PERNR = associate.PERNR;

                FirstName = associate.Entity.FirstName;
                LastName = associate.Entity.LastName;
                CostCenter = associate.Department?.Abbreviation;
                Gender = associate.Entity.Sex?.ShortCode;
            }

            public string PERNR { get; set; }
            public string? FirstName { get; set; }
            public string LastName { get; set; }
            public string? CostCenter { get; set; }
            public string? Gender { get; set; }
        }
    }


    public class SearchAssociateQueryHandler : IQueryHandler<SearchAssociatesQuery, SearchAssociatesResult>
    {
        private ILogger Logger { get; }
        private int DefaultMaxPageSize { get; }
        private IRMXContext dbContext { get; }


        public SearchAssociateQueryHandler(ILogger logger, IConfiguration config, IRMXContext context)
        {
            Logger = logger;
            DefaultMaxPageSize = (int.Parse(config["MaxItemsReturned"] ?? "50"));
            dbContext = context;
        }


        public async Task<SearchAssociatesResult> Handle(SearchAssociatesQuery request, CancellationToken cancellationToken)
        {
            if (request.PageSize < 0)
            {
                request.PageSize = DefaultMaxPageSize;
            }

            SearchAssociatesResult result = new SearchAssociatesResult
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Results = await SearchAssociates(request)
            };

            return await Task.FromResult(result);
        }


        private async Task<IEnumerable<SearchAssociatesResult.SearchResult>> SearchAssociates(SearchAssociatesQuery request)
        {
            string empNum = request.PERNR!.FixWildcards();
            string first = request.FirstName!.FixWildcards();
            string last = request.LastName!.FixWildcards();
            string center = request.CostCenter!.FixWildcards();

            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last) &&
                string.IsNullOrEmpty(empNum) && string.IsNullOrEmpty(center))
            {
                throw new ArgumentNullException("At least one parameter is required.");
            }

            IQueryable<AssociateEntity> emps = dbContext.Associates.AsNoTracking().Where(e =>
                                    e.Entity.FirstName.Contains(first) &&
                                    (!string.IsNullOrEmpty(first) ? !String.IsNullOrEmpty(e.Entity.FirstName) : true) &&
                                    e.Entity.LastName.Contains(last) &&
                                    (!string.IsNullOrEmpty(last) ? !String.IsNullOrEmpty(e.Entity.LastName) : true) &&
                                    e.Department.Abbreviation.Contains(center) && (!string.IsNullOrEmpty(center) ? !String.IsNullOrEmpty(e.Department.Abbreviation) : true) &&
                                    e.PERNR.Contains(empNum) && (!string.IsNullOrEmpty(empNum) ? !String.IsNullOrEmpty(e.PERNR) : true))
                                    .Include(a => a.Entity)
                                        .ThenInclude(e => e.Sex)
                                    .Include(a => a.Department)
                                    .Skip((request.Page - 1) * request.PageSize)
                                    .Take(request.PageSize);

            Logger.LogInformation("SQL:" + emps.ToSql(), null);
            System.Diagnostics.Debug.WriteLine(emps.ToSql());

            var data = emps.ToList();

            return await Task.FromResult(data.Select(a => new SearchAssociatesResult.SearchResult(a)).ToList());
        }
    }

}
