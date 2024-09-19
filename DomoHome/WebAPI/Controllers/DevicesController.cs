//using BusinessLogic;
//using Domain;
using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.In;
using Models.Out;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceLogic _deviceLogic;
    
        public DevicesController(IDeviceLogic deviceLogic)
        {
            _deviceLogic = deviceLogic;
        }


        [HttpGet]
        public IActionResult GetDevicesByName([FromQuery] string? contains, [FromQuery] int page = 1, [FromQuery] int pageSize = 4)
        {
            string[] devices = { "Camara", "Sensor", "Door", "Window" };

            var filteredDevices = devices.AsQueryable();

            if (!string.IsNullOrEmpty(contains))
            {
                filteredDevices = filteredDevices.Where(d => d.Contains(contains, StringComparison.OrdinalIgnoreCase));
            }

            var pagedDevices = filteredDevices
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return Ok(pagedDevices);
        }

        [HttpGet("{Name}")]
        public IActionResult GetDeviceByName([FromQuery] string? endsWith)
        {
            string[] devices = { "Camera", "Sensor", "Door", "Window" };

            var filteredDevices = devices.AsQueryable();

            if (!string.IsNullOrEmpty(endsWith))
            {
                filteredDevices = filteredDevices.Where(d => d.EndsWith(endsWith, StringComparison.OrdinalIgnoreCase));
            }

            return Ok(filteredDevices.ToList());
        }

        [HttpPost]
        public IActionResult CreateDevice([FromBody] CreateDeviceRequest device)
        {
            CreateDeviceResponse response = new CreateDeviceResponse()
            {
                Name = device.Name,
                Type = device.Type,
                Model = device.Model,
                Description = device.Description,
                PhotoPath = device.PhotoPath,
                OwningCompany = device.OwningCompany,
                isInline = device.isInline,
                movementDetection = device.movementDetection,
                personDetection = device.personDetection
            };

            return Created(string.Empty, response);           
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteDevice(string name)
        {
            List<string> devices = new List<string> { "Camera", "Sensor", "Door", "Window" };
            var device = devices.FirstOrDefault(d => d.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (device == null)
            {
                return NotFound(new { message = "Device not found" });
            }

            devices.Remove(device);
            return NoContent();  // 204 No Content
        }

       /* [HttpPut("{name}")]
        public IActionResult UpdateDevice(string name, [FromBody] UpdateDeviceRequest device)
        {
            List<string> devices = new List<string> { "Camera", "Sensor", "Door", "Window" };
            var deviceToUpdate = devices.FirstOrDefault(d => d.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (deviceToUpdate == null)
            {
                return NotFound(new { message = "Device not found" });
            }

            devices.Remove(deviceToUpdate);
            devices.Add(device.Name);
            return NoContent();  // 204 No Content
        }*/


    }
}
