using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PowerSarj_2022.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChargerRouter:ControllerBase
    {
        [HttpGet("/info")]
        public IActionResult actionResult()
        {
            return Ok();
        }


        [HttpGet("/mobilcheck")]
        public IActionResult mobilcheck()
        {
            return Ok();
        }



        [HttpGet("/start")]
        public IActionResult Start()
        {
            return Ok();
        }


        [HttpGet("/stop")]
        public IActionResult Stop()
        {
            return Ok();
        }

    }
}
