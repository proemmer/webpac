using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


/// <summary>
/// https://github.com/aspnet/SignalR-Server/blob/dev/samples/SignalRSample.Web/Hubs/DemoHub.cs
/// </summary>
namespace webpac.Hubs
{
    [HubName("webpac")]
    public class WebpacHub : Hub
    {

        public WebpacHub()
        {

        }
    }
}
