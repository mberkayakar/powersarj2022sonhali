using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PowerSarj_2022.Business.Concrete.DTO;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete.Dtos;

namespace PowerSarj_2022.WebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UsersController : ControllerBase
    {


        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;



        public UsersController(IUserService userservice , ILogger<UsersController> logger)
        {
            _userService = userservice;
            _logger = logger;

        }


        [HttpGet]  // Tamamlandı 
        public IActionResult GetAllUsers()      
        {
            _logger.LogTrace("Tüm Userların Listelenmesi için istek gelindi ");
                var model = _userService.GetAllUsers();

            if (model != null)
            {
                 return Ok(model);
            }
            else
            {
                return NotFound("Sistemde Kayıtlı herhangi bir kullanıcı bulunamadı ");
            }

        }




        [HttpGet("{_id}")]    // tamamlandı 
        public IActionResult GetAllUsersWithId(string _id)
        {

            var model = _userService.GetAllUsers(x=> x._id== _id);

            if (model != null)
            {
                 return Ok(model);
            }
            else
            {
                return NotFound("Sistemde Kayıtlı herhangi bir kullanıcı bulunamadı ");
            }

         }




        [HttpGet("bysite/{sitename}")]  // tamamlandı 
        public IActionResult GetAllUserWithSiteParameter(string sitename)
        {
            var model = _userService.GetAllUsers(x => x.site == sitename);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }


        [HttpPost]      // tüm işlemleri tamamlandı // bir user a birden çok device durumu gerçekleştr , aynı device birden çok kullanıcıya da atılmaktadır.  // operasyonlar ilk etapta gelmedipği için ve filler boş bıkaktım sonrasında repository kısmında süreç düzenlenebilir 
        public IActionResult SaveUser(UserSaveDto userdto)
        {
            _userService.SaveUser(userdto); 
            return Ok(userdto);
        }










        [HttpPost("addoperation")]   // add operation da user a operation eklemek 
        public IActionResult AddOperationFromUser(AddOperationFromUser userdto)
        {
            if (userdto != null)
            {
                _userService.UpdatedUserModel(filter: x=> x.userid ==  userdto.userid ,addoperationfromuser: userdto);
                return Ok(userdto);

            }
            else
            {
                return BadRequest();
            }

        }

       
        
        [HttpPost("login")]   
        public IActionResult Loginevent(UserLoginDto userlogindto)
        {
            if (userlogindto.Password != "" && userlogindto.UserId != "")
            {
                var model = _userService.UserLogin(userlogindto);
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest("Lütfen Geçerli Bir şifre ve kullanıcıbilgisi giriniz ");
        }



        [HttpDelete("{id}")]   
        public IActionResult DeleteUser(string id)
        {
            if (id != null && id!= "" )
            {
                var model = _userService.DeleteUserWithUserId(id);
                if (model != null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }

            return BadRequest("Lütfen Geçerli Bir şifre ve kullanıcıbilgisi giriniz ");
        }

        [HttpPut("{id}")]   
        public IActionResult UpdateUserİnformation(UserUpdateDTO userdto)
        {

            if (userdto.userid!=null)
            {
                _userService.UpdatedUserModel(userdto);
            return Ok(userdto);

            }
            else
            {
                return NotFound("Bu şekilde bir user sistemde kayıtlı değildir. Bu sebepten ötürü güncelleme gerçekleşmemiştir.");
            }
        }

        
        #region Eski Kodlar 

        //[HttpPost]  // fils ve operation kaydedemiyor tek problemi o onun üzerinde yogunlaşacagız ..
        //public IActionResult SaveUSer([FromBody] User user)
        //{
        //    if (user != null)
        //    {
        //        _userService.Add(user);


        //        return Ok(user);
        //    }

        //    return BadRequest("İşlem tamamlanamadı bir problem meydana geldi ");


        //}


        //[HttpGet("aaa")]
        //public IActionResult Index()
        //{
        //    // https://www.c-sharpcorner.com/blogs/eager-loading-in-repository-pattern-entity-framework-core

        //    //var model = _userService.GetAllUserİnformation(
        //    //    filter: x => x.userid == "" && x.balance != 0  ,  ;



        //    //if (model != null)
        //    //{
        //    //    return Ok(model);

        //    //}
        //    //else
        //    //{
        //    //    return NotFound(model);
        //    //}


        //    return Ok();

        //}
        #endregion

    }
}
