using Microsoft.Extensions.Logging;
using Moq;
using Webpac.Hubs;
using Webpac.Interfaces;
using Xunit;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace UnitTestSuit
{
    public class WebpacHubTest
    {
        [Fact]
        public void SubscribeReturnsTrue()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeChanges(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Subscribe("Test", "Test");
            Assert.True(response);
        }

        [Fact]
        public void SubscribeReturnsTrueWithoutVariable()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Subscribe("Test");
            Assert.True(response);
        }

        [Fact]
        public void SubscribeReturnsFalseBecauseOfMappingService()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Subscribe("Test", "Test");
            Assert.False(response);
        }


        [Fact]
        public void SubscribeReturnsFalseBecauseOfMappingEmpty()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Subscribe("", "Test");
            Assert.False(response);
        }

        [Fact]
        public void SubscribeReturnsFalseBecauseOfMappingNull()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Subscribe(null, "Test");
            Assert.False(response);
        }


        [Fact]
        public void UnsubscribeReturnsTrue()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Unsubscribe("Test", "Test");
            Assert.True(response);
        }

        [Fact]
        public void UnsubscribeReturnsTrueWithoutVariable()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Unsubscribe("Test");
            Assert.True(response);
        }

        [Fact]
        public void UnsubscribeReturnsFalseBecauseOfMappingService()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Unsubscribe("Test", "Test");
            Assert.False(response);
        }


        [Fact]
        public void UnsubscribeReturnsFalseBecauseOfMappingEmpty()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Unsubscribe("", "Test");
            Assert.False(response);
        }

        [Fact]
        public void UnsubscribeReturnsFalseBecauseOfMappingNull()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.Unsubscribe(null, "Test");
            Assert.False(response);
        }



        [Fact]
        public void SubscribeRawReturnsTrue()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.SubscribeRaw("Test", "Test");
            Assert.True(response);
        }

        [Fact]
        public void SubscribeRawReturnsFalseWithoutAddress()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.SubscribeRaw("Test");
            Assert.False(response);
        }

        [Fact]
        public void SubscribeRawReturnsFalseBecauseOfMappingService()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.SubscribeRaw("Test", "Test");
            Assert.False(response);
        }


        [Fact]
        public void SubscribeRawReturnsFalseBecauseOfAreaEmpty()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.SubscribeRaw("", "Test");
            Assert.False(response);
        }

        [Fact]
        public void SubscribeRawReturnsFalseBecauseOfAreaNull()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.SubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.SubscribeRaw(null, "Test");
            Assert.False(response);
        }


        [Fact]
        public void UnsubscribeRawReturnsTrue()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(true);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.UnsubscribeRaw("Test", "Test");
            Assert.True(response);
        }

        [Fact]
        public void UnsubscribeRawReturnsFalseWithoutAddress()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.UnsubscribeRaw("Test");
            Assert.False(response);
        }

        [Fact]
        public void UnsubscribeRawReturnsFalseBecauseOfMappingService()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.UnsubscribeRaw("Test", "Test");
            Assert.False(response);
        }


        [Fact]
        public void UnsubscribeRawReturnsFalseBecauseOfAreaEmpty()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.UnsubscribeRaw("", "Test");
            Assert.False(response);
        }

        [Fact]
        public void UnsubscribeRawReturnsFalseBecauseOfAreaNull()
        {
            var mockMappingService = new Mock<IMappingService>();
            var mockLogger = new Mock<ILogger<WebpacHub>>();
            var mockcontext = new Mock<HubCallerContext>();
            mockMappingService.Setup(m => m.UnsubscribeRawChanges(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>())).Returns(false);
            mockcontext.Setup(m => m.ConnectionId).Returns("XYZ");

            var hub = new WebpacHub(mockMappingService.Object, mockLogger.Object);
            hub.Context = mockcontext.Object;
            var response = hub.UnsubscribeRaw(null, "Test");
            Assert.False(response);
        }
    }
}
