using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EstateApi.AcceptanceTest.Helpers
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> GetWithExpectedStatusCodeAsync(this HttpClient httpClient, string url, HttpStatusCode expectedStatusCode)
        {
            var response = await httpClient.GetAsync(url);
            response.StatusCode.Should().Be(expectedStatusCode);

            return response;
        }
    }
}
