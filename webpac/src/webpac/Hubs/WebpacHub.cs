using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
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

        public async Task<bool> Subscribe(string mapping, params string[] variables)
        {
            return await Task.FromResult(false);
        }

    }
}
