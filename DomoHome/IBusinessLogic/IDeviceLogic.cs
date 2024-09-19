using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusinessLogic
{
    public interface IDeviceLogic
    {
        List<Device> GetDevicesByName(string name);
        Device GetDeviceByName(string name);
        Device CreateDevice(Device device);
    }
}
