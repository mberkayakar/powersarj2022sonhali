using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Business.Concrete.DTO;
using PowerSarj_2022.Business.Concrete.DTO.FillDto;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PowerSarj_2022.DataAccess.Abstract
{



    public class UserManager : GenericManager<User>, IUserService
    {

        private readonly IUserRepository _userService;
        private readonly IDeviceRepository _deviceRepository;

        private readonly DbContext _db;

        public UserManager(IUserRepository genericRepository, DbContext db, IDeviceRepository deviceRepository) : base(genericRepository)
        {
            _db = db;
            _userService = genericRepository;
            _deviceRepository = deviceRepository;


        }


        // Çalışıyor
        public IEnumerable<UserListDto> GetAllUsers(Expression<Func<User, bool>> filter = null)
        {
            var model = new List<User>();

            if (filter != null)
            {

                model = _userService.GetAllWıthInclude(filter, x => x.fills, x => x.devices, x => x.operations).ToList();


                //model = _db.Set<User>().Include(x => x.fills).Include(x => x.operations).Include(y => y.devices).Where(filter).ToList();
            }
            else
            {
                model = _userService.GetAllWıthInclude(null, x => x.fills, x => x.devices, x => x.operations).ToList();


                //model = _db.Set<User>().Include(x => x.fills).Include(x => x.operations).Include(y => y.devices).ToList();

            }




            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new UserListMapper());
            });

            var mapper = configuration.CreateMapper();

            var model2 = mapper.Map<List<UserListDto>>(model);




            List<Device> devices2 = new List<Device>();
            foreach (var item in model)
            {

                // operasyonlar içerisindeki user ları silme işlemi 
                foreach (var operation in item.operations)
                {
                    if (operation != null)
                    {
                        operation.user = null;
                    }
                }


                foreach (var fill in item.fills)
                {
                    if (fill != null)
                    {
                        fill.user = null;
                    }
                }




                List<string> suruculer = new List<string>();

                foreach (var item2 in item.devices)
                    suruculer.Add(item2.deviceid);

                model2.FirstOrDefault(x => x.userid == item.userid).devices = suruculer;
            }




            return model2;
        }

        // Çalışıyor
        public IEnumerable<User> GetAllUserİnformation(Expression<Func<User, bool>> filter, params Expression<Func<User, object>>[] children)
        {
            throw new NotImplementedException();
        }

        // Çalışıyor
        public void SaveUser(UserSaveDto usermodule)
        {

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new UserToUserSaveMapping());
            });

            var mapper = configuration.CreateMapper();

            var model = mapper.Map<User>(usermodule);

            model.date = DateTime.Now;
            model.devices = new List<Device>();


            foreach (var item in usermodule.devices)
            {
                try
                {
                    dynamic singledevice = _deviceRepository.GetObject(x => x.deviceid == item);
                    //_db.Set<Device>().FirstOrDefault(x => x.devicename == item);
                    if (singledevice != null)
                    {
                        model.devices.Add(singledevice);
                    }

                }
                catch (ArgumentException ex)
                {
                }
            }

            _userService.Add(model);




        }


        public User UpdatedUserModel(AddOperationFromUser addoperationfromuser, Expression<Func<User, bool>> filter = null)
        {
            var model = _db.Set<User>().Where(filter).Include(x => x.fills).FirstOrDefault();

            if (model != null)
            {
                if (model.fills == null)
                {
                    model.fills = new List<Fill>();
                }




                // gelen nesneyi Fill e çevireceğiz .


                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new AddFillDtoMapper());
                });

                var mapper = configuration.CreateMapper();
                var model2 = mapper.Map<Fill>(addoperationfromuser);
                //model2.user = model;
                 

                model.fills.Add(model2);

            }
            else
            {
                return null;
            }

            _userService.Update(model);

            return model;



        }


        // Çalışıyor
        public User UserLogin(UserLoginDto userlogindto)
        {


            dynamic model = _userService.GetAll(x => x.userid == userlogindto.UserId && x.password == userlogindto.Password).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        // Çalışıyor
        public User DeleteUserWithUserId(string userid)
        {

            var model = _userService.GetObject(x => x._id == userid);
            _userService.Delete(model);
            return model;
        }

        public User UpdatedUserModel(UserUpdateDTO userUpdateDTO)
        {
            //var model = _userService.GetObject(x => x.userid == userUpdateDTO.userid); // include atılmıyo

            var model = _db.Set<User>().Include(x => x.devices).Include(x => x.operations).Include(x => x.fills).FirstOrDefault(x => x._id == userUpdateDTO._id);

            if (model != null)
            {

                #region DTO DAN GELEN VERİ BİR USER VERİSİNE DÖNÜŞTÜRLDÜ 

                //var configuration = new MapperConfiguration(opt =>
                //{
                //    opt.AddProfile(new UserDTOtoUserMapper());
                //});

                //var mapper = configuration.CreateMapper();
                //var model2 = mapper.Map<User>(userUpdateDTO);



                model.cardid = (userUpdateDTO.cardid!= null) ?  userUpdateDTO.cardid : model.cardid;
                model.username = (userUpdateDTO.username != null) ?   userUpdateDTO.username  : model.username;
                model.site = (userUpdateDTO.site != null) ? userUpdateDTO.site : model.site;
                model.password =( userUpdateDTO.password != null) ? userUpdateDTO.password  : model.password ;
                model.__v = ( userUpdateDTO.__v != null) ? userUpdateDTO.__v  : model.__v;
                model.chargingdevice = (userUpdateDTO.chargingdevice != null) ? userUpdateDTO.chargingdevice : model.chargingdevice;
                model.updatedAt = DateTime.Now;
                model.balance = userUpdateDTO.balance;



                if (model.devices!=null)
                {

                    if (userUpdateDTO.devices!=null)
                    {

                    model.devices.Clear();
                    List<string> cachedevice = new List<string>();
                    foreach (var item in userUpdateDTO.devices)
                    {
                        var device = _deviceRepository.GetObject(x => x.deviceid == item);
                        if (device != null)
                        {
                            model.devices.Add(device);
                        }
                    }
                    }


                }




                _userService.Update(model);

                return model;





                #endregion






                #region User - User Mapplenmesi (dto dan user a dönen veri bir daha user dan user a maplenmek istedi)


                //var configuration2 = new MapperConfiguration(opt =>
                //{
                //    opt.AddProfile(new UserToUserMapperForUpdateEvent());
                //});

                //var mapper2 = configuration2.CreateMapper();
                //var model3 = mapper2.Map<User>(model2);


                //model = model3;
                #endregion




            }
            else
            {
                return null;
            }





        }

        public UserListDto GetUser(Expression<Func<User, bool>> filter = null)
        {
            var model = new User();

            if (filter != null)
                model = _userService.GetAllWıthInclude(filter, x => x.fills, x => x.devices, x => x.operations).FirstOrDefault();
            else
                model = _userService.GetAllWıthInclude(null, x => x.fills, x => x.devices, x => x.operations).FirstOrDefault();


            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new UserListMapper());
            });

            
            
            var mapper = configuration.CreateMapper();
            var model2 = mapper.Map<UserListDto>(model);
            List<Device> devices2 = new List<Device>();




            foreach (var operation in model.operations)
            {
                if (operation != null)
                {
                    operation.user = null;
                }
            }

            foreach (var fill in model.fills)
            {
                if (fill != null)
                {
                    fill.user = null;
                }
            }



            List<string> suruculer = new List<string>();

            foreach (var item2 in model.devices)
                suruculer.Add(item2.deviceid);

            model2.devices = suruculer;


            return model2;
        } 
    }
}

