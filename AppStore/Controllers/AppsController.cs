using AppStore.BL.Interfaces;
using AppStore.Models.DTO;
using AppStore.Models.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppsController : ControllerBase
    {

        private readonly IAppService _appService;
        private readonly IMapper _mapper;

        public AppsController(IAppService appService, IMapper mapper){
            _appService = appService;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            var result = _appService.GetAllApps();

            if (result == null || result.Count == 0)
            {
                return NotFound("No apps found");
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id can't be null or empty");
            }

            var result = _appService.GetAppById(id);

            if (result == null)
            {
                return NotFound($"App with ID:{id} not found");
            }

            return Ok(result);
        }


        [HttpPost("Add")]
        public IActionResult Add(App app)
        {
            try
            {
                var appDto = _mapper.Map<AppDTO>(app);

                if (appDto == null)
                {
                    return BadRequest("Can't convert app to movie DTO");
                }

                _appService.AddApp(appDto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                // _logger.LogError(ex, $"Error adding movie with");
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Delete")]
        public IActionResult Delete(string id)
        {
            // if (id <= 0)
            // {
            //     return BadRequest("Id must be greater than 0");
            // }

            _appService.DeleteApp(id);


            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update(string Id,App app)
        {
            try
            {
                var appDto = _mapper.Map<AppDTO>(app);

                if (appDto == null)
                {
                    return BadRequest("Can't convert app to movie DTO");
                }

                _appService.UpdateApp(Id,appDto);

                return Ok();
            }
            catch (System.Exception ex)
            {
                // _logger.LogError(ex, $"Error adding movie with");
                return BadRequest(ex.Message);
            }
        }

    }
}
