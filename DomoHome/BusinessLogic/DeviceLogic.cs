using Domain;
using IBusinessLogic;


namespace BusinessLogic
{
    public class DeviceLogic : IDeviceLogic
    {
        public Device CreateDevice(Device device)
        {
            Console.WriteLine("Creating device!");
            return device;
        }

        public Device GetDeviceByName(string name)
        {//Metodo MUY mejorable (viola Clean Code por todos lados)
            string[] devices = { "Camara", "Sensor", "Door", "Window" };
            List<Device> listDevices = (from device in devices
                                      where device.ToLower().Equals(name.ToLower())
                                      select device).Select(s => new Device { Name = name }).ToList();
            if (listDevices.Count == 0) return null;
            return listDevices[0];
        }

        public List<Device> GetDevicesByName(string name)
        {
            return new List<Device>()
            {
                new Device()
                {
                    Name = "The " + name
                }
            };
        }

      

        
    }
}
