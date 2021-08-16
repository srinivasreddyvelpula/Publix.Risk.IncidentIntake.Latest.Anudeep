using Microsoft.Extensions.Logging;
using Publix.Risk.IncidentIntake.Domain.Interfaces;
using Publix.Risk.IncidentIntake.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.Domain.Features.Code
{
    public class GetCodesListQuery : IQuery<GetCodesListResult>
    {
        public GetCodesListQuery()
        {
        }
    }


    public class GetCodesListResult : IEnumerable<CodeType>
    {
        private List<CodeType> list = new List<CodeType>();


        public GetCodesListResult(IEnumerable<CodeType> initalData)
        {
            if (initalData == null)
            {
                list = new List<CodeType>();
            }
            else
            {
                list = initalData.ToList();
            }
        }


        public IEnumerator<CodeType> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }


    public class GetCodesListQueryHandler : IQueryHandler<GetCodesListQuery, GetCodesListResult>
    {
        private ILogger Logger { get; }


        public GetCodesListQueryHandler(ILogger logger)
        {
            Logger = logger;
        }


        public async Task<GetCodesListResult> Handle(GetCodesListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                GetCodesListResult result = new GetCodesListResult(await GetCodeTypes());

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Unable to Get Code List", request);
                return await Task.FromResult(new GetCodesListResult(null));
            }
        }


        private async Task<IEnumerable<CodeType>?> GetCodeTypes()
        {
            return await Task.FromResult(CodeType.GetAll().ToList());
        }

    }

}
