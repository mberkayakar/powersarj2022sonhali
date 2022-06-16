using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerSarj_2022.Business.Abstract;

namespace PowerSarj_2022.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChargerRouter:ControllerBase
    {
        private readonly Logger<ChargerRouter> _logger;
        private readonly IChargeService _service;
        public ChargerRouter( IChargeService service)
        {
            //_logger = logger;
            _service = service;
        }



        [HttpGet("/info")]
        public IActionResult actionResult([FromQuery]string deviceid, [FromQuery] string state, [FromQuery] string charginguser, [FromQuery] string cardid)
        {
            var model = _service.INFO(deviceid, state, charginguser, cardid);
            return Ok(model);
        }


        [HttpGet("/mobilcheck")]
        public IActionResult mobilcheck([FromQuery] string deviceid, [FromQuery] string state, [FromQuery] string charginguser, [FromQuery] string cardid)
        {
            var model = _service.MOBILCHECK(deviceid, state, charginguser, cardid);
            return Ok(model);
        }



        [HttpGet("/start")]
        public IActionResult Start(string deviceid, string state, string charginguser, string cardid)
        {
            var model = _service.START(deviceid, state, charginguser, cardid);
            return Ok(model);
        }


        [HttpGet("/stop")]
        public IActionResult Stop(string deviceid, string state, string charginguser, string cardid)
        {
            var model = _service.STOP(deviceid, state, charginguser, cardid);
            return Ok(model);
        }

    }
}
