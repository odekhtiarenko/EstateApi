using EstateApi.Data;
using EstateApi.Handlers.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EstateApi.Handlers.QueryHandlers
{
    public class GetTopActiveRealEstateAgentsQueryHandler : IRequestHandler<GetTopActiveRealEstateAgentsQuery, IEnumerable<RealEstateAgent>>
    {
        public async Task<IEnumerable<RealEstateAgent>> Handle(GetTopActiveRealEstateAgentsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<RealEstateAgent>());
        }
    }
}
