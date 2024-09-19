using DataAccess.Context;
using Domain;
using IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceContext _devicesContext;

        public DeviceRepository(DeviceContext devicesContext)
        {
            _devicesContext = devicesContext;
        }

        public Device GetDeviceById(string name)
        {   try
                {
                return _devicesContext.Devices.FirstOrDefault(d => d.Name == name);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Bad");
            }        
        }
    }
}
