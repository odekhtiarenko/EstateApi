using AutoFixture;
using AutoMapper;
using EstateApi.AutoMapperProfile;
using EstateApi.Controllers;
using EstateApi.Data;
using EstateApi.Dto;
using EstateApi.Handlers.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EstateApi.Api.Tests
{
    public class RealEstateAgentControllerTests
    {
        private readonly RealEstateAgentController _controller;
        private readonly Fixture _fixture;
        private readonly Mock<IMediator> _mediatorMoq;

        public RealEstateAgentControllerTests()
        {
            _fixture = new Fixture();
            _mediatorMoq = new Mock<IMediator>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            var mapper = config.CreateMapper();

            _controller = new RealEstateAgentController(_mediatorMoq.Object, mapper);
        }

        [Fact]
        public async Task GetTopActive_shouldReturnCollectionOf10RealEstateAgentStats()
        {
            var location = "amsterdam";
            _mediatorMoq.Setup(x => x.Send(It.Is<GetTopActiveRealEstateAgentsQuery>(q => q.Location == "location"), new CancellationToken()))
                        .ReturnsAsync(_fixture.CreateMany<RealEstateAgent>());

            var result = (OkObjectResult)await _controller.GetTopActive(location);

            result.Should()
                .NotBeNull();

            result.Value.Should()
                        .BeAssignableTo<IEnumerable<RealEstateAgentStats>>();
        }
    }
}
