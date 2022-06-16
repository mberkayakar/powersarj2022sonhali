using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete.Dtos;
using PowerSarj_2022.Entities.Concrete.Dtos.AdminDtoFolder;

namespace PowerSarj_2022.WebApi.Controllers
{



    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController:ControllerBase
    {
        private readonly Logger<AdminController> _logger;
        private readonly IAdminService _service;
        public AdminController( IAdminService service )
        {
            _service = service;
        }


        [Route("/login")]
        [HttpPost]
        public IActionResult Login(AdminLoginDto adminLoginDto)
        {
            if (adminLoginDto.username!= null && adminLoginDto.password!="")
            {
                var model = _service.Authenticate(adminLoginDto.username , adminLoginDto.password);
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
        public IActionResult GetAdmin(AdminUpdateDto adminUpdate , string id  )
        {
            if (adminUpdate == null && (id != null || id != ""))
            {
                var model = _service.Update(adminUpdate, id);
                if (model!=null)
                {
                    return Ok(model);

                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
