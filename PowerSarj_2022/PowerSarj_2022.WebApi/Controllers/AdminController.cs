using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete.Dtos;

namespace PowerSarj_2022.WebApi.Controllers
{



    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController:ControllerBase
    {
        private readonly Logger<AdminController> _logger;
        private readonly IAdminService _service;
        public AdminController(
            
            //Logger<AdminController> logger,
            
            IAdminService service )
        {
            //_logger = logger;
            _service = service;
        }



        [Route("/login")]
        [HttpPost]
        public IActionResult Login(AdminLoginDto adminLoginDto)
        {
            if (adminLoginDto.username!= null && adminLoginDto.password!="")
            {
                var model = _service.GetObject(x => x.username== adminLoginDto.username && x.password == adminLoginDto.password);
                if (model!= null)
                {




                    return Ok(model);

                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
             return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult GetAdmin()
        {
            return Ok();
        }
    }
}
