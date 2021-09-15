using AutoMapper;
using EstateApi.Dto;
using EstateApi.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateAgentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RealEstateAgentController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{location}/top-most-active")]
        public async Task<IActionResult> GetTopActive(string location, string filter = null)
        {
            var realEstateAgents = await _mediator.Send(new GetTopActiveRealEstateAgentsQuery(location, filter));
            return Ok(_mapper.Map<IEnumerable<RealEstateAgentStats>>(realEstateAgents));
        }
    }
}
