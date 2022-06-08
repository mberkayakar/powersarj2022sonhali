using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PowerSarj_2022.Business.Concrete;
using PowerSarj_2022.Business.Concrete.DTO.DeviceDto;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public class DeviceManager : GenericManager<Device>, IDeviceService
    {


        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserRepository _userrepository;

        private readonly DbContext _dbContext;
        public DeviceManager(IDeviceRepository _deviceService , DbContext db , IUserRepository userrepo ) : base(_deviceService)
        {
            _dbContext = db;
            _userrepository = userrepo;
            _dbContext = db;
            _deviceRepository = _deviceService;


        }

        public SaveDeviceDto AddDevice(SaveDeviceDto device)
        {

            // Böyle bir device id ye sahip bir cihaz varmı ona bakıyoruz. beraberinde ise o device sistemde yoksa 
            // böyle bir işlem mümkün kılınıyoer varsa , bu id ye sahip bir device daha sisteme eklenemiyor
            var model = _deviceRepository.GetObject(x => x.deviceid == device.deviceid);

            if (model == null)
            {

                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new DeviceSaveMapper());
                });


                var mapper = configuration.CreateMapper();

                var model2 = mapper.Map<Device>(device);


                if (model2.allowedSites == null)
                {
                    model2.allowedSites = new List<AllowedSites>();
                }

                foreach (var item in device.allowedsites)
                {
                    var site_verable = _dbContext.Set<AllowedSites>().FirstOrDefault(x => x.Name == item);
                    if (site_verable != null)
                    {
                        model2.allowedSites.Add(site_verable);
                    }
                    
                }

                //if (model2.operations!=null)
                //{
                //    model2.operations = new List<Operation>();
                //    foreach (var item in device.operations)
                //    {
                //        model2.operations.Add(item);

                //    }

                //}

                _deviceRepository.Add(model2);


                return device;

            }
            else
            {
                return null;
            }
        }

        public void DeleteDevice(string _id)
        {
            var model = _deviceRepository.GetObject(x => x.deviceid == _id);
            if (model != null)
            {
                _deviceRepository.Delete(model);
            }
                 
        }

        public IEnumerable<ListDeviceDto> GetAllDevice(Expression<Func<Device, bool>> filter = null)
        {

            var model = new List<Device>();

            if (filter == null)

                model = _deviceRepository.GetAllWıthInclude(where: null, x => x.allowedSites, x => x.operations).ToList();
            else

                model = _deviceRepository.GetAllWıthInclude(where: filter, x => x.allowedSites, x => x.operations).ToList() ;


            if (model != null)
            {

                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new DeviceListMapper());

                });
                var mapper = configuration.CreateMapper();
                var model2 = mapper.Map<List<ListDeviceDto>>(model);



                //foreach (var item in model)
                //{
                //    List<string> devicelist = new List<string>();

                //    foreach (var item2 in item.allowedSites)
                //    {
                //        devicelist.Add(item2.Name);
                //    }

                //    model2.FirstOrDefault(x => x._id == item._id).allowedSites = allowedsitetostring;


                //}


                //foreach (var item in model)
                //{
                //    List<string> allowedsitetostring = new List<string>();

                //    foreach (var item2 in item.)
                //    {
                //        allowedsitetostring.Add(item2.Name);
                //    }

                //    model2.FirstOrDefault(x => x._id == item._id).allowedSites = allowedsitetostring;


                //}

                //foreach (var item in model2)
                //{
                //    foreach (var item2 in item.operations)
                //    {
                //        //item.user
                //    }
                //}





                #region MyRegion
                //if (model2.operations!=null)
                //{
                //    model2.operations = new List<Operation>();
                //    foreach (var item in device.operations)
                //    {
                //        model2.operations.Add(item);

                //    }

                //}

                #endregion

                return model2;

            }
            else
            {
                return null;
            }
        }

        public IEnumerable<ListDeviceDtoNoOperation> GetAllDeviceWithNoOperation(Expression<Func<Device,bool>> filter = null)
        {
            var model = _deviceRepository.GetAllWıthInclude(where: filter, x => x.allowedSites, x => x.operations);

            if (model != null)
            {


                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new DeviceListWitouthOperationMapper());

                });



                var mapper = configuration.CreateMapper();
                var model2 = mapper.Map<List< ListDeviceDtoNoOperation>>(model);





                foreach (var item in model)
                {
                    List<string> allowedsitetostring = new List<string>();

                    foreach (var item2 in item.allowedSites)
                    {
                        allowedsitetostring.Add(item2.Name);
                    }

                    model2.FirstOrDefault(x => x._id == item._id).allowedSites = allowedsitetostring;


                }


                //if (model2.operations!=null)
                //{
                //    model2.operations = new List<Operation>();
                //    foreach (var item in device.operations)
                //    {
                //        model2.operations.Add(item);

                //    }

                //}





                return model2 ;

            }
            else
            {
                return null;
            }
        }

        public ListDeviceDtoNoOperation GetAllDeviceWithNoOperationOneObject (Expression<Func<Device, bool>> filter = null)
        {
            var model = _deviceRepository.GetAllWıthInclude(where: filter, x => x.allowedSites, x => x.operations);

            if (model != null)
            {


                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new DeviceListWitouthOperationMapper());

                });



                var mapper = configuration.CreateMapper();
                var model2 = mapper.Map<List<ListDeviceDtoNoOperation>>(model);





                foreach (var item in model)
                {
                    List<string> allowedsitetostring = new List<string>();

                    foreach (var item2 in item.allowedSites)
                    {
                        allowedsitetostring.Add(item2.Name);
                    }

                    model2.FirstOrDefault(x => x._id == item._id).allowedSites = allowedsitetostring;


                }


                //if (model2.operations!=null)
                //{
                //    model2.operations = new List<Operation>();
                //    foreach (var item in device.operations)
                //    {
                //        model2.operations.Add(item);

                //    }

                //}





                return model2.FirstOrDefault() ;

            }
            else
            {
                return null;
            }
        }

        public GetOneDeviceDto GetOneDeviceByFilter(Expression<Func<Device, bool>> filter = null)
        {
            var model = new Device();

            if (filter == null)
                model = _deviceRepository.GetAllWıthInclude(where: null, x => x.allowedSites, x => x.operations , x=> x.User).FirstOrDefault();
            else
                model = _deviceRepository.GetAllWıthInclude(where: filter, x => x.allowedSites, x => x.operations, x => x.User).FirstOrDefault();


            if (model != null)
            {

                var configuration = new MapperConfiguration(opt =>
                {
                    opt.AddProfile(new DeviceGetOneMapper());

                });



                var mapper = configuration.CreateMapper();
                var model2 = mapper.Map<GetOneDeviceDto>(model);



                List<string> allowedsitetostring = new List<string>();
                foreach (var item in model.allowedSites)
                {
                    allowedsitetostring.Add(item.Name);
                }
                model2.allowedsites = allowedsitetostring;

                return model2;

            }
            else
            {
                return null;
            }


        }


        #region Eski Kodlar 

        //public List<ListDeviceDto> GetAllDevice(Expression<Func<Device, bool>> where = null, params Expression<Func<Device, object>>[] includeProperty)
        //{
        //    var model1 = _userrepository.GetAll();
        // <   var model2 = _dbContext.Set<Device>().Include(x => x.User).Include(x => x.allowedSites).ToList();

        //    var model = _deviceRepository.GetAllWıthInclude(where, includeProperty);



        //}
        #endregion
    }
}
