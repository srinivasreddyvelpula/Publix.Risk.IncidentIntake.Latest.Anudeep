using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Code
{
    public class GetCodesQuery : IQuery<GetCodesResult>
    {
        public int CodeTypeId { get; set; }
        public string? FilteredOn { get; set; }

        public GetCodesQuery(int codeTypeId, string? filteredOn = null)
        {
            CodeTypeId = codeTypeId;
            FilteredOn = filteredOn;
        }
    }


    public class GetCodesResult
    {
        public GetCodesResult(IEnumerable<CodeEntity>? codes)
        {
            if (codes == null)
            {
                Codes = new List<CodeEntity>();
            }
            else
            {
                Codes = codes;
            }
        }

        public IEnumerable<CodeEntity> Codes { get; set; }
    }


    public class GetCodesQueryHandler : IQueryHandler<GetCodesQuery, GetCodesResult>
    {
        private ILogger Logger { get; }
        private IRMXContext dbContext { get; }


        public GetCodesQueryHandler(ILogger logger, IRMXContext context)
        {
            Logger = logger;
            dbContext = context;
        }


        public async Task<GetCodesResult> Handle(GetCodesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetCodesResult result = new GetCodesResult(await GetCodes(request.CodeTypeId, request.FilteredOn));

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unable to get Codes", request);
                throw;
            }
        }

        private async Task<IEnumerable<CodeEntity>?> GetCodes(int codeTypeId, string? filterOn)
        {
            CodeType codeType = CodeType.FromValue(codeTypeId);
            if (codeType != null)
            {
                switch (codeType.ListType)
                {
                    case "Simple":
                        return await Task.FromResult(GetCodes(codeType).Result.ToList());

                    case "Hierarchical":
                        return await Task.FromResult(GetCodesFromEntities(codeType).Result.ToList());

                    case "Filtered":
                        if (string.IsNullOrEmpty(filterOn))
                        {
                            return await Task.FromResult(GetCodes(codeType).Result.ToList());
                        }
                        else
                        {
                            return await Task.FromResult(GetFilteredCodes(codeType, filterOn).Result.ToList());
                        }

                    default:
                        return null;
                };
            }
            else
                return null;
        }

        private async Task<IEnumerable<CodeEntity>> GetFilteredCodes(CodeType codeType, string filterOn)
        {
            return await Task.FromResult(dbContext.CodeByType(codeType).ToList());
        }

        private async Task<IEnumerable<CodeEntity>> GetCodesFromEntities(CodeType codeType)
        {
            return await Task.FromResult(dbContext.EntityCodesByType(codeType).ToList());
        }

        private async Task<IEnumerable<CodeEntity>> GetCodes(CodeType codeType)
        {
            return await Task.FromResult(dbContext.CodeByType(codeType).ToList());
        }
    }

}
