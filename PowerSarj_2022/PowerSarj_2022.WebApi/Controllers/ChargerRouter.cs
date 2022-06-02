using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PowerSarj_2022.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ChargerRouter:ControllerBase
    {
        [HttpGet]
        public IActionResult deneme()
        {
            return Ok();
        }
    }
}
