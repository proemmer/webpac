using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Interfaces;

/// <summary>
/// https://github.com/aspnet/SignalR-Server/blob/dev/samples/SignalRSample.Web/Hubs/DemoHub.cs
/// </summary>
namespace webpac.Hubs
{
    [HubName("webpac")]
    public class WebpacHub : Hub
    {

        private IMappingService _mappingService;

        public WebpacHub(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public async Task<string> JoinGroup(string connectionId, string groupName)
        {
            await Groups.Add(connectionId, groupName);
            return connectionId + " joined " + groupName;
        }

        public async Task<string> LeaveGroup(string connectionId, string groupName)
        {
            await Groups.Remove(connectionId, groupName);
            return connectionId + " joined " + groupName;
        }


        //public async Task<bool> Subscribe(string )
        //{

        //}

    }
}
