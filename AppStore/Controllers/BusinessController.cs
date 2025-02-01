using AppStore.BL.Interfaces;
using AppStore.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IAppBlService _appService;
        private readonly IOperatingSystemService _osService;

        public BusinessController(IAppBlService appService, IOperatingSystemService osService){
            _appService = appService;
            _osService = osService;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllAppsWithDetails")]
        public IActionResult GetAllAppsWithDetails()
        {
            var result = _appService.GetDetailedApps();

            if (result == null || result.Count == 0)
            {
                return NotFound("No apps found");
            }

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("AddOperatingSystem")]
        public IActionResult AddOperatingSystem([FromBody] OperatingSystemDTO os)
        {
            _osService.AddOperatingSystem(os);

            return Ok();
        }
    }
}
