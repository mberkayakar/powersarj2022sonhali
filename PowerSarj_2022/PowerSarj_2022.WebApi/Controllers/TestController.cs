using Microsoft.AspNetCore.Mvc;

namespace PowerSarj_2022.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TestController:ControllerBase
    {

        [HttpGet]
        public IActionResult Deneme() // SANIRIM ÇALIŞTI AMA DB YE BAĞLANAMADIpublish al bakim nolacak
        {
            return Ok("Deneme 123 Proje çalışıyor");
        }
    }
}
