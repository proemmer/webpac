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
            _mappingService.DataChanged += _mappingService_DataChanged;
        }

        protected override void Dispose(bool disposing)
        {
            _mappingService.DataChanged -= _mappingService_DataChanged;
            base.Dispose(disposing);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _mappingService.RemoveSubscriptionsForId(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }


        public bool Subscribe(string mapping, params string[] variables)
        {
            return _mappingService.SubscribeChanges(Context.ConnectionId, mapping, variables);
        }

        public bool Unsubscribe(string mapping, params string[] variables)
        {
            return _mappingService.UnsubscribeChanges(Context.ConnectionId, mapping, variables);
        }

        private void _mappingService_DataChanged(List<SubscriptionInformationPackage> package)
        {
            foreach (var item in package)
                Clients.Clients(item.Subscribers.ToList()).DataChanged(item.Mapping, item.Variable, item.Value);
        }

    }
}
