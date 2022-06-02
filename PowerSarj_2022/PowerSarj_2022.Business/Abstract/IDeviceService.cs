using PowerSarj_2022.Business.Abstract;
using PowerSarj_2022.Entities.Concrete;
using PowerSarj_2022.Entities.Concrete.Dtos;
using PowerSarj_2022.Entities.Concrete.Dtos.DeviceDTOFolder;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PowerSarj_2022.DataAccess.Abstract
{
    public interface IDeviceService : IGenericService<Device>
    {
        IEnumerable<ListDeviceDto>  GetAllDevice(Expression<Func<Device, bool>> filter = null);
        IEnumerable<ListDeviceDtoNoOperation> GetAllDeviceWithNoOperation(Expression<Func<Device,bool>> filter = null);
        ListDeviceDtoNoOperation GetAllDeviceWithNoOperationOneObject(Expression<Func<Device, bool>> filter = null);
        SaveDeviceDto AddDevice (SaveDeviceDto device);

         
    }
}
