
using Microsoft.AspNetCore.Mvc;
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
        private readonly ILoggerFactory _loggerFactory;

        public BaseController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ILogger Logger
        {
            get
            {
                return _logger ?? (_logger = _loggerFactory.CreateLogger(GetType().Name));
            }
        }
    }
}
