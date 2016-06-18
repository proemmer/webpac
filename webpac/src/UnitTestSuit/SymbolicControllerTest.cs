using Moq;
using System.Collections.Generic;
using System.Linq;
using webpac.Controllers;
using webpac.Interfaces;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UnitTestSuit
{
    /// <summary>
    /// To use mock, add an reference to  System.Diagnostics.TraceSource  !!!
    /// </summary>
    public class SymbolicControllerTest
    {

        [Fact]
        public void GetReturnsEmptyList()
        {
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.GetSymbols()).Returns(new List<string>());

            var controller = new SymbolicController(mockMappingService.Object);
            var response = controller.Get();
            Assert.False(response.Any());
        }

        [Fact]
        public void GetReturnsListWithItems()
        {
            var mockMappingService = new Mock<IMappingService>();
            var list = new List<string>{ "TestElement1", "TestElement2" }; 
            mockMappingService.Setup(m => m.GetSymbols()).Returns(list);
            var controller = new SymbolicController(mockMappingService.Object);
            var response = controller.Get();
            Assert.False(list.Except(response).Any());
        }

        [Fact]
        public void GetWithBadRequestResult()
        {
            var mapping = "";
            var variable = "";
            var expected = new Dictionary<string, object> { { mapping, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping,variable);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void GetWithNotFoundRequestResult()
        {
            var mapping = "XYZ";
            var variable = "";
            var expected = new Dictionary<string, object>();
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.Read(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping, variable);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetWithCorrectObjectRequestResult()
        {
            var mapping = "Test";
            var variable = "";
            var expected = new Dictionary<string, object> { { mapping, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.Read(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping, variable);

            Assert.IsType<ObjectResult>(response);
            var or = response as ObjectResult;
            Assert.Equal(expected, or.Value);
        }



        [Fact]
        public void GetWithParamsWithBadRequestResult()
        {
            var mapping = "";
            var expected = new Dictionary<string, object> { { mapping, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping, new string[] { });

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void GetWithParamsWithNotFoundRequestResult()
        {
            var mapping = "XYZ";
            var expected = new Dictionary<string, object>();
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.Read(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping, new string[] { });

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetWithParamsWithCorrectObjectRequestResult()
        {
            var mapping = "Test";
            var expected = new Dictionary<string, object> { { mapping, 0 } };
            var mockMappingService = new Mock<IMappingService>();

            mockMappingService.Setup(m => m.Read(It.IsAny<string>(), It.IsAny<string>())).Returns(expected);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Get(mapping, new string[] { });

            Assert.IsType<ObjectResult>(response);
            var or = response as ObjectResult;
            Assert.Equal(expected, or.Value);
        }


        [Fact]
        public void PatchWithBadRequestBecauseOfEmptyMapping()
        {
            var mapping = "";
            var toWrite = new Dictionary<string, object> { { "Varname", 0 } };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithBadRequestBecauseOfEmptyValue()
        {
            var mapping = "TEST";
            var toWrite = new Dictionary<string, object> {  };
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithBadRequestBecauseOfNullValue()
        {
            var mapping = "TEST";
            Dictionary<string, object> value = null;
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, value);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchNOkWrite()
        {
            var mapping = "TEST";
            var value = new Dictionary<string, object>{ { "Test", 0 } };
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string,object>>())).Returns(false);
            var controller = new SymbolicController(mockMappingService.Object);

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
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(true);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, value);

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public void PatchWithVariableNOkWrite()
        {
            var mapping = "TEST";
            var variable = "Test";
            var value = 0;
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(false);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, value);

            Assert.IsType<StatusCodeResult>(response);
            Assert.Equal((int)HttpStatusCode.NotModified, (response as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void PatchWithVariableOkWrite()
        {
            var mapping = "TEST";
            var value = new Dictionary<string, object> { { "Test", 0 } };
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(true);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, value);

            Assert.IsType<NoContentResult>(response);
        }

        [Fact]
        public void PatchWithVariableWithBadRequestBecauseOfEmptyMapping()
        {
            var mapping = "";
            var variable = "Test";
            var toWrite = new object();
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithVariableWithBadRequestBecauseOfEmptyVariable()
        {
            var mapping = "TEST";
            var variable = "";
            var toWrite = new object();
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PatchWithVariableWithBadRequestBecauseOfNullValue()
        {
            var mapping = "TEST";
            var variable = "test";
            object toWrite =null;
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Patch(mapping, variable, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PutWithBadRequestBecauseOfEmptyMapping()
        {
            var mapping = "";
            var toWrite = new object();
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Put(mapping, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PutWithBadRequestBecauseOfNullValue()
        {
            var mapping = "Test";
            object toWrite = null;
            var mockMappingService = new Mock<IMappingService>();

            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Put(mapping, toWrite);

            Assert.IsType<BadRequestResult>(response);
        }

        [Fact]
        public void PutNOkWrite()
        {
            var mapping = "TEST";
            var value = new object();
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(false);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Put(mapping, value);

            Assert.IsType<StatusCodeResult>(response);
            Assert.Equal((int)HttpStatusCode.NotModified, (response as StatusCodeResult).StatusCode);
        }

        [Fact]
        public void PutOkWrite()
        {
            var mapping = "TEST";
            var value = new object();
            var mockMappingService = new Mock<IMappingService>();
            mockMappingService.Setup(m => m.Write(It.IsAny<string>(), It.IsAny<Dictionary<string, object>>())).Returns(true);
            var controller = new SymbolicController(mockMappingService.Object);

            var response = controller.Put(mapping, value);

            Assert.IsType<NoContentResult>(response);
        }


    }
}
