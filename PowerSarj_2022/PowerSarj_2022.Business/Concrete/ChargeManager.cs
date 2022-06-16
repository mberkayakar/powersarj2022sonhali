using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.DataAccess.Abstract;
using PowerSarj_2022.Entities.Concrete;
using System;

namespace PowerSarj_2022.Business.Concrete
{
    public class ChargeManager : IChargeService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserRepository _userrepository;


        public ChargeManager(IUserRepository userrepo, IDeviceRepository deviceRepository  ) 
        {
            _userrepository = userrepo;
            _deviceRepository = deviceRepository;
        }
        
        public string INFO(string deviceid, string state , string charginguser , string cardid)
        {
            User user = null;
            Device device = _deviceRepository.GetObject(x => x.deviceid == deviceid);
            
            if (device == null)
            {
                return "<PC><MESSAGE>" + device.deviceid + " CIHAZ YOK</MESSAGE></PC>";
            }
            else
            {
                if (device.mobilecharging != "" || device.mobilecharging != null)
                {
                    device.state = state;
                    device.charginguser = charginguser;
                    device.date = System.DateTime.Now;
                    _deviceRepository.Update(device);



                    user = _userrepository.GetObject(x => x.cardid == cardid);
                    if (user==null)
                    {
                        return "<PC>MOBILECHARGE" + device.mobilecharging + "<MESSAGE>" + device.deviceid + " " + device.site + "-KULLANICI YOK!-DK UCRET:" + device.price + " TL</MESSAGE></PC>";
                    }
                    else
                    {
                        return "<PC>MOBILECHARGE" + device.mobilecharging + "<MESSAGE>" + device.deviceid + " " + device.site + "-" + user.userid + " " + (int)user.balance + "TL-DK UCRET:" + device.price + " TL</MESSAGE></PC>";
                    }

                }
                else
                {
                    device = _deviceRepository.GetObject(x => x.deviceid == deviceid);
                    device.state = state;
                    device.charginguser = "";
                    device.date = DateTime.Now;
                    _deviceRepository.Update(device);

                    user = _userrepository.GetObject(x => x.cardid == cardid);
                    if (user == null)
                    {
                        return "<PC>MOBILECHARGE" + device.mobilecharging + "<MESSAGE>" + device.deviceid + " " + device.site + "-KULLANICI YOK!-DK UCRET:" + device.price + " TL</MESSAGE></PC>";
                    }
                    else
                    {
                        return "<PC>MOBILECHARGE" + device.mobilecharging + "<MESSAGE>" + device.deviceid + " " + device.site + "-" + user.userid + " " + (int)user.balance + "TL-DK UCRET:" + device.price + " TL</MESSAGE></PC>";
                    }

                }
            }




        }
        public string MOBILCHECK(string deviceid, string state, string charginguser, string cardid)
        {
            User user = null;
            Device device = _deviceRepository.GetObject(x => x.deviceid == deviceid);

            if (device == null)
            {
                return "<PC><MESSAGE>" + device.deviceid + " CIHAZ YOK</MESSAGE></PC>";
            }
            else
            {
                if (device.mobilecharging != "" || device.mobilecharging != null)
                {
                    device.state = state;
                    device.charginguser = charginguser;
                    device.date = System.DateTime.Now;
                    _deviceRepository.Update(device);

                    return "<PC><MC>" + device.mobilecharging + "</MC></PC>";
                }
                else
                {
                    return "<PC></PC>";
                }
            }
        }
        public string START(string deviceid, string state, string charginguser, string cardid)
        {
            User user = null;
            Device device = _deviceRepository.GetObject(x => x.deviceid == deviceid);

            if (device == null)
            {
                return "<PC>NOCHARGE<MESSAGE>"+device.deviceid+" "+device.site+"-YETKISIZ-DK UCRET:"+device.price+" TL </ MESSAGE ></ PC > ";
            }
            else
            {
                user = _userrepository.GetObject(x => x.cardid == cardid &&  x.site == device.site );
                if (user == null)
                {
                    device.state = "0";
                    device.charginguser = "";
                    device.date = System.DateTime.Now;
                    _deviceRepository.Update(device);

                    return "<PC>NOCHARGE<MESSAGE>" + device.deviceid + " " + device.site + "-KULLANICI YOK-DK UCRET:" + device.price + " TL</MESSAGE></PC>";
                }
                else if (user.balance < device.price)
                {
                    device.state = "0";
                    device.charginguser = "";
                    device.date = System.DateTime.Now;
                    _deviceRepository.Update(device);
                    return "<PC>NOCHARGE<MESSAGE>" + device.deviceid + " " + device.site + "-BAKIYE YETERSIZ-DK UCRET:" + device.price + " TL</MESSAGE></PC>";

                }
                else
                {
                    user.chargingdevice = device.deviceid;
                    user.updatedAt = DateTime.Now;
                    _userrepository.Update(user);

                    device.state = "1";
                    device.charginguser = user.userid;
                    device.mobilecharging= "";
                    device.date = DateTime.Now;
                    _deviceRepository.Update(device);

                    return "<PC>STARTCHARGE" + (int)(user.balance / device.price) + "<MESSAGE>" + device.deviceid + " " + device.site + "-" + user.cardid + " " + (int)(user.balance) + "TL-DK UCRET:" + device.price + " TL</MESSAGE><USER>" + user.cardid + "</USER></PC>";

                }
            }
        }
        public string STOP(string deviceid, string state, string charginguser, string cardid)
        {
            User user = null;
            Device device = _deviceRepository.GetObject(x=> x._id == "asd");




            return "";
                 
        }
    }
}
