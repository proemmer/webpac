using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webpac.Filters
{
    /// <summary>
    /// https://damienbod.com/2015/09/15/asp-net-5-action-filters/
    /// This Filter is used to log all Actions on the controllers
    /// </summary>
    public class ActionLoggerFilter : ActionFilterAttribute
    {
        private ILogger _logger;
        public ILoggerFactory LoggerFactory { get; set; }
        public ILogger Logger
        {
            get
            {
                return _logger ?? (_logger = LoggerFactory.CreateLogger(GetType().Name));
            }
        }

        public ActionLoggerFilter(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Logger.LogInformation("OnActionExecuting");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Logger.LogInformation("OnActionExecuted");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Logger.LogInformation("OnResultExecuting");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Logger.LogInformation("OnResultExecuted");
            base.OnResultExecuted(context);
        }

    }
}
