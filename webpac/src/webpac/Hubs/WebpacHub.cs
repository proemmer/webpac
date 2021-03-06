﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Webpac.Interfaces;

/// <summary>
/// https://github.com/aspnet/SignalR-Server/blob/dev/samples/SignalRSample.Web/Hubs/DemoHub.cs
/// </summary>
namespace Webpac.Hubs
{
    [HubName("webpac")]
    [Authorize(Roles = "ReadOnly,ReadWrite,Admin")]
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
        }

        /// <summary>
        /// Remove event handle from mapping service
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is call when a client is connected.
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            _logger.LogInformation($"Client {Context.ConnectionId} connected");
            _mappingService.AddConnectionSubscriber(Context.ConnectionId);
            return base.OnConnected();
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
            _mappingService.RemoveConnectionSubscriber(Context.ConnectionId);
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
            if (string.IsNullOrWhiteSpace(mapping))
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to subscribe to mapping with null value");
                return false;
            }
            if (variables == null || !variables.Any())
                variables = new string[] { "This" };
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
            if (string.IsNullOrWhiteSpace(mapping))
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to unsubscribe from mapping with null value");
                return false;
            }
            if (variables == null || !variables.Any())
                variables = new string[] { "This" };
            _logger.LogInformation($"Client {Context.ConnectionId}: stop subscription to mapping {mapping} and variables {variables.Aggregate((a, b) => $"{a},{b}")} ");
            return _mappingService.UnsubscribeChanges(Context.ConnectionId, mapping, variables);
        }

        /// <summary>
        /// Call this method to subscribe variables for data change
        /// </summary>
        /// <param name="area">name of the used area (e.g. DB100, FB, IB, QB,..)</param>
        /// <param name="adresses">adresses for watching</param>
        /// <returns></returns>
        public bool SubscribeRaw(string area, params string[] adresses)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to subscribe to area with null value");
                return false;
            }
            if (string.IsNullOrWhiteSpace(area) || !adresses.Any())
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to subscribe to area {area} with null value in address");
                return false;
            }
            _logger.LogInformation($"Client {Context.ConnectionId}: start subscription to area {area} and addresses {adresses.Aggregate((a, b) => $"{a},{b}")} ");
            return _mappingService.SubscribeRawChanges(Context.ConnectionId, area, adresses);
        }

        /// <summary>
        /// Call this method to unsubscribe variables for data change
        /// </summary>
        /// <param name="area">name of the used area (e.g. DB100, FB, IB, QB,..)</param>
        /// <param name="adresses">adresses for watching</param>
        /// <returns></returns>
        public bool UnsubscribeRaw(string area, params string[] adresses)
        {
            if (string.IsNullOrWhiteSpace(area))
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to unsubscribe from area with null value");
                return false;
            }
            if (string.IsNullOrWhiteSpace(area) || !adresses.Any())
            {
                _logger.LogError($"Client {Context.ConnectionId}: tries to unsubscribe from area {area} with null value in address");
                return false;
            }
            _logger.LogInformation($"Client {Context.ConnectionId}: stop subscription to area {area} and addresses {adresses.Aggregate((a, b) => $"{a},{b}")} ");
            return _mappingService.UnsubscribeRawChanges(Context.ConnectionId, area, adresses);
        }

    }
}
