using System.Collections.Generic;
using System.Linq;

namespace Publix.Risk.IncidentIntake.Domain.Core.Model
{
    public class SearchResultModel<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int Count => Results.Count();
        public IEnumerable<T> Results { get; set; }

    }
}
