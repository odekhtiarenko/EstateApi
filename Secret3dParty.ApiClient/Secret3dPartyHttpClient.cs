using Newtonsoft.Json;
using Secret3dParty.ApiClient.Abstraction;
using Secret3dParty.ApiClient.Configuration;
using Secret3dParty.ApiClient.Contracts;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Secret3dParty.ApiClient
{
    public class Secret3dPartyHttpClient : ISecret3dPartyHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string GET_ESTATES_FOR_SALE = "?type=koop&zo=/";

        public Secret3dPartyHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<RealEstatesResponse> GetRealEstates(string location, int page, int pagesize, string filter = null)
        {
            var httpClient = _httpClientFactory.CreateClient(ApiClientConfiguration.Secret3dPartyClientName);

            var result = await httpClient.GetAsync(GetUri(location, page, pagesize, filter));
            var jsonStr = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<RealEstatesResponse>(jsonStr);
        }

        private string GetUri(string location, int page, int pagesize, string filter = null)
        {
            var sb = new StringBuilder();

            sb.Append($"{GET_ESTATES_FOR_SALE}{location}/");

            if (filter != null)
                sb.Append($"{filter}/");

            sb.Append($"&page={page}&pagesize={pagesize}");

            var uri = sb.ToString();
            return uri;
        }
    }
}
