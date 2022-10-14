using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace JsonBasedLocalization.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IStringLocalizer<DemoController> _loc;

        public DemoController(ILogger<DemoController> logger, IStringLocalizer<DemoController> loc)
        {
            _logger = logger;
            _loc = loc;
        }

        [HttpGet]
        public IActionResult GetHi()
        {
            try
            {
                _logger.LogInformation(_loc["hi"]);
                var message = _loc["hi"].ToString();
                return Ok(message);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
            
        }

        [HttpGet("{name}")]
        public IActionResult GetNight(string name)
        {
            try
            {
                var message = string.Format(_loc["Night"], name);
                return Ok(message);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

        }
        [HttpGet]
        public IActionResult GetALl()
        {
            try
            {
                var message = _loc.GetAllStrings();
                return Ok(message);

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse();
                response.Success = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
