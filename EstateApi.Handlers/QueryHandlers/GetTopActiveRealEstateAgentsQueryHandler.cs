using EstateApi.Data;
using EstateApi.Handlers.Queries;
using MediatR;
using Secret3dParty.ApiClient.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace EstateApi.Handlers.QueryHandlers
{
    public class GetTopActiveRealEstateAgentsQueryHandler : IRequestHandler<GetTopActiveRealEstateAgentsQuery, IEnumerable<RealEstateAgent>>
    {
        private readonly ISecret3dPartyHttpClient _httpClient;

        public GetTopActiveRealEstateAgentsQueryHandler(ISecret3dPartyHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstateAgent>> Handle(GetTopActiveRealEstateAgentsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<Secret3dParty.ApiClient.Contracts.Property>();

            var pages = 1;
            var pageSize = 25;

            for (int page = 1; page <= pages; page++)
            {
                var repsonse = await _httpClient.GetRealEstates(request.Location, page, pageSize, request.Filter);
                result.AddRange(repsonse.Objects);

                pages = repsonse.Paging.AantalPaginas;
            }

            return result.GroupBy(x => x.MakelaarId,
                                  (a, b) => new RealEstateAgent()
                                  {
                                      Id = a,
                                      Name = b.First().MakelaarNaam,
                                      Properties = b.Select(x => new Property
                                      {
                                          Address = x.Adres,
                                          OfferedSince = x.AangebodenSindsTekst
                                      })
                                  })
                            .OrderByDescending(x=>x.Properties.Count())
                            .Take(10);
        }
    }
}
