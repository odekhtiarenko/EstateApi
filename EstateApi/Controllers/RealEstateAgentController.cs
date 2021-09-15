using EstateApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateAgentController : ControllerBase
    {
        [HttpGet("{location}/top-most-active")]
        public async Task<IActionResult> GetTopActive(string location, string filter = null)
        {
            var result = new List<RealEstateAgentStats>();

            return Ok(await Task.FromResult(result));
        }
    }
}
