using AutoFixture;
using EstateApi.Data;
using EstateApi.Handlers.Queries;
using EstateApi.Handlers.QueryHandlers;
using FluentAssertions;
using Moq;
using Secret3dParty.ApiClient.Abstraction;
using Secret3dParty.ApiClient.Contracts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EstateApi.Handlers.Tests
{
    public class GetTopActiveRealEstateAgentsQueryHandlerTests
    {
        private readonly GetTopActiveRealEstateAgentsQueryHandler _handler;
        private readonly IFixture _fixture;
        private readonly Mock<ISecret3dPartyHttpClient> _httpClientMoq;

        public GetTopActiveRealEstateAgentsQueryHandlerTests()
        {
            _fixture = new Fixture();
            _httpClientMoq = new Mock<ISecret3dPartyHttpClient>();

            _handler = new GetTopActiveRealEstateAgentsQueryHandler(_httpClientMoq.Object);
        }

        [Theory]
        [InlineData("amsterdam", null)]
        [InlineData("amsterdam", "Tuin")]
        public async Task Handle_ShouldReturnCollectionOfTopActiveRealEstateAgents(string location, string filter)
        {
            var response = _fixture.Create<RealEstatesResponse>();

            _httpClientMoq.Setup(x => x.GetRealEstates(location, It.IsAny<int>(), It.IsAny<int>(), filter))
                .ReturnsAsync(response);

            var result = await _handler.Handle(new GetTopActiveRealEstateAgentsQuery(location, filter), new CancellationToken());

            result.Should()
                .BeAssignableTo<IEnumerable<RealEstateAgent>>();
        }
    }
}
