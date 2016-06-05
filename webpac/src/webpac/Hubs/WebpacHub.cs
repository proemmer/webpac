using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Interfaces;

/// <summary>
/// https://github.com/aspnet/SignalR-Server/blob/dev/samples/SignalRSample.Web/Hubs/DemoHub.cs
/// </summary>
namespace webpac.Hubs
{
    /// <summary>
    /// We do not use authorization for this hub because this force longpolling!!
    /// </summary>
    [HubName("webpac")]
    public class WebpacHub : Hub<IWebpacClient>
    {
        private IMappingService _mappingService;
        private ILogger _logger;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mappingService"></param>
        public WebpacHub(IMappingService mappingService, ILogger<WebpacHub> logger )
        {
            _mappingService = mappingService;
            _logger = logger;
            _mappingService.DataChanged += _mappingService_DataChanged;
        }

        /// <summary>
        /// Remove event handle from mappingservice
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _mappingService.DataChanged -= _mappingService_DataChanged;
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method will be called when client is disconnected,
        /// so all active variables for this client will be deactivated
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            _logger.LogInformation($"Client {Context.ConnectionId} disconnected (stop call={stopCalled})");
            _mappingService.RemoveSubscriptionsForId(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Call this method to subscribe variables for data change
        /// </summary>
        /// <param name="mapping">name of the used mapping</param>
        /// <param name="variables">variable names for watching</param>
        /// <returns></returns>
        public bool Subscribe(string mapping, params string[] variables)
        {
            _logger.LogInformation($"Client {Context.ConnectionId}: start subscription to mapping {mapping} and variables {variables.Aggregate((a,b) => $"{a},{b}")} ");
            return _mappingService.SubscribeChanges(Context.ConnectionId, mapping, variables);
        }

        /// <summary>
        /// Call this method to unsubscribe variables for data change
        /// </summary>
        /// <param name="mapping">name of the used mapping</param>
        /// <param name="variables">variable names for watching</param>
        /// <returns></returns>
        public bool Unsubscribe(string mapping, params string[] variables)
        {
            _logger.LogInformation($"Client {Context.ConnectionId}: stop subscription to mapping {mapping} and variables {variables.Aggregate((a, b) => $"{a},{b}")} ");
            return _mappingService.UnsubscribeChanges(Context.ConnectionId, mapping, variables);
        }

        /// <summary>
        /// This method is called when data are changed
        /// </summary>
        /// <param name="package"></param>
        private void _mappingService_DataChanged(List<SubscriptionInformationPackage> package)
        {
            foreach (var item in package)
            {
                _logger.LogInformation($"Data change occurred for mapping {item.Mapping} and variable {item.Variable}.");
                Clients.Clients(item.Subscribers.ToList()).DataChanged(item.Mapping, item.Variable, item.Value);
            }
        }

    }
}
