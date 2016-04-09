using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Filters;

namespace webpac.Controllers
{
    [ServiceFilter(typeof(ActionLoggerFilter))]

    [Route("api/[controller]")]
    public class BaseController
    {
        private ILogger _logger;
        [FromServices]
        public ILoggerFactory LoggerFactory { get; set; }
        public ILogger Logger
        {
            get
            {
                return _logger ?? (_logger = LoggerFactory.CreateLogger(GetType().Name));
            }
        }
    }
}
