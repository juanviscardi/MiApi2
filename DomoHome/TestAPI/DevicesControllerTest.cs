using Domain;
using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Models.Out;
using Models.In;
using Moq;
using WebAPI.Controllers;

namespace TestAPI
{
    [TestClass]
    public class DevicesControllerTest
    {
        private DevicesController _devicesController;
        private RetrieveDeviceResponse _retrieveDevicesResponse;
        private Device _device;

        [TestInitialize]
        public void Setup()
        {
            _retrieveDevicesResponse = new RetrieveDeviceResponse() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true };
            _device = new Device() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true };
        }


        [TestCleanup]
        public void Cleanup()
        {
            _devicesController = null;
            _retrieveDevicesResponse = null;
            _device = null;
        }

        [TestMethod]
        public void GetDevicesByNameOk()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.GetDevicesByName(It.IsAny<string>())).Returns(new List<Device>() { _device });
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.GetDevicesByName("Test");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetDevicesByNameNoContent()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.GetDevicesByName(It.IsAny<string>())).Returns(new List<Device>());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.GetDevicesByName("Test");

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void GetDeviceByNameOk()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.GetDeviceByName(It.IsAny<string>())).Returns(_device);
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.GetDeviceByName("Test");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetDeviceByNameNoContent()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.GetDeviceByName(It.IsAny<string>())).Returns((Device)null);
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.GetDeviceByName("Test");

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public void CreateDeviceOk()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Returns(_device);
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void CreateDeviceBadRequest()
        {
            // Arrange
            var deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Returns((Device)null);
            var devicesController = new DevicesController(deviceLogicMock.Object);

            var createDeviceRequest = new CreateDeviceRequest
            {
                Name = "Test",
                Type = "Test",
                Model = "Test",
                Description = "Test",
                PhotoPath = "Test",
                OwningCompany = "Test",
                isInline = true
            };

            // Act
            var result = devicesController.CreateDevice(createDeviceRequest);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerError()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CreateDeviceBadRequestNull()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Returns((Device)null);
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerErrorNull()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerErrorException()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerErrorExceptionNull()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerErrorExceptionBadRequest()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void CreateDeviceInternalServerErrorExceptionBadRequestNull()
        {
            // Arrange
            Mock<IDeviceLogic> deviceLogicMock = new Mock<IDeviceLogic>(MockBehavior.Strict);
            deviceLogicMock.Setup(logic => logic.CreateDevice(It.IsAny<Device>())).Throws(new Exception());
            _devicesController = new DevicesController(deviceLogicMock.Object);
            RetrieveDeviceResponse expectedResult = _retrieveDevicesResponse;

            // Act
            var result = _devicesController.CreateDevice(new CreateDeviceRequest() { Name = "Test", Type = "Test", Model = "Test", Description = "Test", PhotoPath = "Test", OwningCompany = "Test", isInline = true });

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
        }
    }
}