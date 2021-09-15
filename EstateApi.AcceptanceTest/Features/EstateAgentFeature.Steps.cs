using EstateApi.AcceptanceTest.Helpers;
using EstateApi.Dto;
using FluentAssertions;
using LightBDD.XUnit2;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EstateApi.AcceptanceTest.Features
{
    public partial class EstateAgentFeature : FeatureFixture,
                                              IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _httpClient;

        private readonly string _location = "amsterdam";
        private readonly string _filter = "tuin";

        private IEnumerable<RealEstateAgentStats> _topAgents;

        public EstateAgentFeature(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        private async Task Given_CallToTopRealEstateAgentsByLocation()
        {
            var repsonse = await _httpClient.GetWithExpectedStatusCodeAsync("/api/RealEstateAgent/amsterdam/top-most-active", System.Net.HttpStatusCode.OK);
            _topAgents = await repsonse.Content.DeserializeAsync<IEnumerable<RealEstateAgentStats>>();
        }

        private async Task Given_CallToTopRealEstateAgentsByLocationAndFilter()
        {
            var repsonse = await _httpClient.GetWithExpectedStatusCodeAsync("/api/RealEstateAgent/amsterdam/top-most-active?filter=tuin", System.Net.HttpStatusCode.OK);
            _topAgents = await repsonse.Content.DeserializeAsync<IEnumerable<RealEstateAgentStats>>();
        }

        private void Then_Top10RealEstateAgentsShoulBeRetrivedInDescendingOrder()
        {
            _topAgents.Should()
                      .BeInDescendingOrder(x => x.PropertiesCount)
                      .And
                      .HaveCount(10);
        }
    }
}
