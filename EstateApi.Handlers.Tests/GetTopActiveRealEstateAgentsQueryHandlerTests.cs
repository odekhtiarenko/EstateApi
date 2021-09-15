using EstateApi.Data;
using EstateApi.Handlers.Queries;
using EstateApi.Handlers.QueryHandlers;
using FluentAssertions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EstateApi.Handlers.Tests
{
    public class GetTopActiveRealEstateAgentsQueryHandlerTests
    {
        private readonly GetTopActiveRealEstateAgentsQueryHandler _handler;

        public GetTopActiveRealEstateAgentsQueryHandlerTests()
        {
            _handler = new GetTopActiveRealEstateAgentsQueryHandler();
        }

        [Fact]
        public async Task Handle_ShouldReturnCollectionOfTopActiveRealEstateAgents()
        {
            var result = await _handler.Handle(new GetTopActiveRealEstateAgentsQuery("amsterdam"), new CancellationToken());

            result.Should()
                .BeAssignableTo<IEnumerable<RealEstateAgent>>();
        }
    }
}
