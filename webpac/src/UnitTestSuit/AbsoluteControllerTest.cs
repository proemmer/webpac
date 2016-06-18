using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using webpac.Controllers;
using webpac.Interfaces;
using Xunit;

namespace UnitTestSuit
{
    public class AbsoluteControllerTest
    {

        [Fact]
        public void GetReturnsEmptyList()
        {
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.GetSymbols()).Returns(new List<string>());

            var controller = new AbsolutesController(mockMappingService.Object);
            var response = controller.Get();
            Assert.False(response.Any());
        }

        [Fact]
        public void GetReturnsListWithItems()
        {
            var mockMappingService = new Mock<IMappingService>();
            var list = new List<string> { "DB1", "DB2" };
            mockMappingService.Setup(m => m.GetDataBlocks()).Returns(list);
            var controller = new AbsolutesController(mockMappingService.Object);
            var response = controller.Get();
            Assert.False(list.Except(response).Any());
        }

        [Fact]
        public void GetWithBadRequestResult()
        {
            var area = "";
            var address = "aa";
            var expected = new Dictionary<string, object> { { address, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, address);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void GetWithNotFoundRequestResult()
        {
            var area = "XYZ";
            var address = "W0";
            var expected = new Dictionary<string, object>();
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.ReadAbs(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, address);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetWithCorrectObjectRequestResult()
        {
            var area = "Test";
            var address = "W0";
            var expected = new Dictionary<string, object> { { area, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.ReadAbs(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, address);

            Assert.IsType<ObjectResult>(response);
            var or = response as ObjectResult;
            Assert.Equal(expected.Values.FirstOrDefault(), or.Value);
        }



        [Fact]
        public void GetWithParamsWithBadRequestResult()
        {
            var area = "";
            var expected = new Dictionary<string, object> { { area, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, new string[] { });

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void GetWithParamsWithNotFoundRequestResult()
        {
            var area = "XYZ";
            var expected = new Dictionary<string, object>();
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.ReadAbs(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, new string[] { "W0" });

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetWithParamsWithNotFoundRequestResult2()
        {
            var area = "XYZ";
            Dictionary<string, object> expected = null;
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.ReadAbs(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, new string[] { "W0" });

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetWithParamsWithCorrectObjectRequestResult()
        {
            var area = "Test";
            var expected = new Dictionary<string, object> { { area, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.ReadAbs(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Get(area, new string[] { "W0" });

            Assert.IsType<ObjectResult>(response);
            var or = response as ObjectResult;
            Assert.Equal(expected, or.Value);
        }


        [Fact]
        public void PatchWithBadRequestBecauseOfEmptyMapping()
        {
            var area = "";
            var toWrite = new Dictionary<string, object> { { "W0", 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Patch(area, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithBadRequestBecauseOfEmptyValue()
        {
            var mapping = "TEST";
            var toWrite = new Dictionary<string, object> { };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Patch(mapping, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithBadRequestBecauseOfNullValue()
        {
            var mapping = "TEST";
            Dictionary<string, object> value = null;
            var mockMappingService = new Mock<IMappingService>();

            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Patch(mapping, value);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchNOkWrite()
        {
            var mapping = "TEST";
            var value = new Dictionary<string, object> { { "Test", 0 } };
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.WriteAbs(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(false);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Patch(mapping, value);

            Assert.IsType<StatusCodeResult>(response);
            Assert.Equal((int)HttpStatusCode.NotModified, (response as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void PatchOkWrite()
        {
            var mapping = "TEST";
            var variable = "Test";
            var value = 0;
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.WriteAbs(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(true);
            var controller = new AbsolutesController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, value);

            Assert.IsType<NoContentResult>(response);
        }
    }
}
