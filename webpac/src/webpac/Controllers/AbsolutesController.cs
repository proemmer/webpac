
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using webpac.Filters;
using webpac.Interfaces;

namespace webpac.Controllers
{
    [ServiceFilter(typeof(ActionLoggerFilter))]
    [Route("api/[controller]")]
    public class AbsolutesController : Controller
    {
        private readonly ILogger _logger;
        //[FromServices]
        public IMappingService MappingService { get; set; }

        public AbsolutesController(IMappingService mappingService, ILoggerFactory loggerFactory, ILogger<AbsolutesController> logger) 
        {
            _logger = logger;
            MappingService = mappingService;
        }


        /// <summary>
        /// Get List of Symbols
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "ReadOnlyPolicy")]
        public IEnumerable<string> Get()
        {
            return MappingService.GetDataBlocks();
        }


        /// <summary>
        /// Read a Symbol
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{area}/{address}")]
        [Produces(typeof(object))]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public IActionResult Get(string area, string address)
        {
            if (string.IsNullOrWhiteSpace(area) || string.IsNullOrWhiteSpace(address))
                return BadRequest();

            var red = MappingService.ReadAbs(area, address).Values.FirstOrDefault();
            if (red == null)
                return NotFound();
            return new ObjectResult(red);
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{area}")]
        [Produces(typeof(IDictionary<string, object>))]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public IActionResult Get(string area, [FromBody]params string[] addresses)
        {
            if (string.IsNullOrWhiteSpace(area) || addresses != null || !addresses.Any())
                return BadRequest();
            var red = MappingService.ReadAbs(area, addresses);
            if (red == null)
                return NotFound();
            return new ObjectResult(red);
        }


        /// <summary>
        /// Write a symbol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPatch("{area}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public IActionResult Patch(string area,[FromBody]Dictionary<string, object> value)
        {
            if (string.IsNullOrWhiteSpace(area) || value == null || !value.Any())
                return BadRequest();
            if (!MappingService.WriteAbs(area, value))
                return StatusCode((int)HttpStatusCode.NotModified);
            return new NoContentResult();
        }

        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPatch("{area}/{variable}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public IActionResult Patch(string area, string address, [FromBody]object value)
        {
            if (string.IsNullOrWhiteSpace(area) || value == null)
                return BadRequest();
            if (!MappingService.WriteAbs(area, new Dictionary<string, object> { { address, value } }))
                return StatusCode((int)HttpStatusCode.NotModified);
            return new NoContentResult();
        }

    }
}
