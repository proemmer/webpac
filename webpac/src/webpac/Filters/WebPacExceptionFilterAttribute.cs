using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Webpac.Filters
{
    public class WebPacExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public WebPacExceptionFilterAttribute(ILogger<WebPacExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError($"OnException: {context.Exception.Message} - {context.Exception.StackTrace}");
            base.OnException(context);
        }
    }
}
