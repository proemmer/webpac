using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using webpac.Hubs;
using webpac.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace webpac.Services
{

    /// <summary>
    /// This class is a connector service between the SignalRHub and the mapping service, to handle callbacks from the mapping service.
    /// This is because a Hub is only instantiate as long as a call is active, but the context exist for all instances, so we get this context injected to this service
    /// and have register the callback only for the context not for the hub instances.
    /// </summary>
    public class RelayService : IRelayService
    {
        private readonly IHubContext<WebpacHub, IWebpacClient> _webPacHubContext;
        private readonly IMappingService _mappingService;
        private readonly ILogger _logger;


        public RelayService(IHubContext<WebpacHub, IWebpacClient> webPacHubContext,
                            IMappingService mappingService,
                            ILogger<RelayService> logger)
        {
            _webPacHubContext = webPacHubContext;
            _mappingService = mappingService;
            _logger = logger;
        }

        public void Configure(IConfigurationSection config)
        {
        }

        public void Init()
        {
            _mappingService.DataChanged += _mappingService_DataChanged;
            _mappingService.PlcConnectionChanged += _mappingService_PlcConnectionChanged;
        }

        public void Release()
        {
        }

        public void Dispose()
        {
            _mappingService.DataChanged -= _mappingService_DataChanged;
            _mappingService.PlcConnectionChanged -= _mappingService_PlcConnectionChanged;
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
                _webPacHubContext?.Clients.Clients(item.Subscribers.ToList()).DataChanged(item.Mapping, item.Variable, item.Value, item.IsRaw);
            }
        }

        /// <summary>
        /// This method is called when plc connection state changed
        /// </summary>
        /// <param name="subscribers"></param>
        /// <param name="state"></param>
        private void _mappingService_PlcConnectionChanged(List<string> subscribers, bool state)
        {
            _webPacHubContext?.Clients.Clients(subscribers).ConnectionChanged(state);
        }
    }
}
