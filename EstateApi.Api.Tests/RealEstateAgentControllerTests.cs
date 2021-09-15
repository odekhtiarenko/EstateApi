using EstateApi.Controllers;
using EstateApi.Dto;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EstateApi.Api.Tests
{
    public class RealEstateAgentControllerTests
    {
        private readonly RealEstateAgentController _controller;

        public RealEstateAgentControllerTests()
        {
            _controller = new RealEstateAgentController();
        }

        [Fact]
        public async Task GetTopActive_shouldReturnCollectionOf10RealEstateAgentStats()
        {
            var result = (OkObjectResult)await _controller.GetTopActive("amsterdam");

            result.Should()
                .NotBeNull();

            result.Value.Should()
                        .BeAssignableTo<IEnumerable<RealEstateAgentStats>>();
        }
    }
}
