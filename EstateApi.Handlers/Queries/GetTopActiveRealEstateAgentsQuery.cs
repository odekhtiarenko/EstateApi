using EstateApi.Data;
using MediatR;
using System.Collections.Generic;

namespace EstateApi.Handlers.Queries
{
    public class GetTopActiveRealEstateAgentsQuery : IRequest<IEnumerable<RealEstateAgent>>
    {
        public string Location { get; }
        public string Filter { get; }

        public GetTopActiveRealEstateAgentsQuery(string location, string filter = null)
        {
            Location = location;
            Filter = filter;
        }
    }
}
