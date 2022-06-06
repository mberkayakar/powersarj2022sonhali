using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;

namespace PowerSarj_2022.WebApi.Controllers
{

    [Authorize]

    [ApiController]
    [Route("[controller]")]
    public class DevicesController:ControllerBase
    {
        private readonly IDeviceService _deviceService;
        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        

        [HttpGet] // automapper ile dönüşüm sağlandı ve bu şekil ön plana getirilmektedir. 
        public IActionResult GetAllDevices()
        {
            var model = _deviceService.GetAllDevice();
            

            if (model!= null)
            {
                return Ok(model);
            }

            return NotFound();
        }



        [HttpGet("list")] // automapper ile tüm verileri getir fonksiyonununn aynısı olup operasyon isimli değişkeni getirmeden iş yapmamaız sağlayacaktır . 
        public IActionResult GetAllDevicesWithoutperations()
        {
            var model = _deviceService.GetAllDeviceWithNoOperation();


            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }



        [HttpGet("list/{_id}")] // automapper ile tüm verileri getir fonksiyonununn aynısı olup operasyon isimli değişkeni getirmeden iş yapmamaız sağlayacaktır . 
        public IActionResult GetAllDevicesWithoutperations(string _id)
        {
            var model = _deviceService.GetAllDeviceWithNoOperationOneObject(x=> x._id == _id);


            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }


        // /list/bysite/:site


        [HttpGet("list/bysite/{_site}")] // automapper ile tüm verileri getir fonksiyonununn aynısı olup operasyon isimli değişkeni getirmeden iş yapmamaız sağlayacaktır . 
        public IActionResult GetAllDevicesWithoutperationsBySite(string _site)
        {
            var model = _deviceService.GetAllDeviceWithNoOperation(x => x.site == _site);


            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }



        [HttpGet("bysite/{_site}")] // operasyonlarıda çekmemiz geremktedeir. 
        public IActionResult Bysitesiteileincludeluvericekme(string _site)
        {
            var model = _deviceService.GetAllDevice(x => x.site == _site);


            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }




        [HttpGet("{_id}")] // Tamamlandı  Burasıda diğerinden farklı olarak operasyonların include atılmış hali ile gelmektedir. 
        public IActionResult GetAllDevicesWithId(string _id)
        {
            var model = _deviceService.GetAllWithİnclude(x => x._id== _id);


            if (model != null)
            {
                return Ok(model);
            }

            return NotFound();
        }






        [HttpPost] // tamamlandı eğer dışarıdan device a  ait bilgiler gelirse (operation fill vs onlarıda map ederek db ye kaydeder )
        public IActionResult SaveDevice(SaveDeviceDto dto)
        {
            if (dto != null)
            {
                var model = _deviceService.AddDevice(dto);               
                return Ok(model);
            }
            
            return BadRequest();
        }

        [HttpPost("/qrcharging")] // tamamlandı eğer dışarıdan device a  ait bilgiler gelirse (operation fill vs onlarıda map ederek db ye kaydeder )
        public IActionResult qrcharging(SaveDeviceDto dto)
        {
            if (dto != null)
            {
                var model = _deviceService.AddDevice(dto);
                return Ok(model);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult updatedeviceinformation(string id)
        {
            return Ok();

        }







        [HttpDelete("_id")]
        public IActionResult DeleteDevice(string _id)
        {
            if (_id !=null || _id != "undefined")
            {
                //_deviceService.Delete(_id);
                return Ok();
            }
            return Ok();


        }


    }
}
