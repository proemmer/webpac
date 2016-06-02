using System;
using System.Collections.Generic;
using System.Linq;
using webpac.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using webpac.Filters;

namespace webpac.Controllers
{
    /// <summary>
    /// UZse Put Or Patch!!!!!?????
    /// https://docs.asp.net/en/latest/tutorials/first-web-api.html
    /// </summary>
    [ServiceFilter(typeof(ActionLoggerFilter))]
    [Route("api/[controller]")]
    public class SymbolicController : Controller
    {
        private readonly ILogger _logger;
        //[FromServices]
        public IMappingService MappingService { get; set; }

        public SymbolicController(  IMappingService mappingService, 
                                    ILoggerFactory loggerFactory,
                                    ILogger<SymbolicController> logger) 
        {
            _logger = logger;
            MappingService = mappingService;
        }

        /// <summary>
        /// Get List of blocks
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "ReadOnlyPolicy")]
        public IEnumerable<string> Get()
        {
            return MappingService.GetSymbols();
        }

        
        /// <summary>
        /// Read a symbol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{mapping}/{variable}")]
        [Produces(typeof(IDictionary<string, object>))]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public IActionResult Get(string mapping, string variable = null)
        {
            if (string.IsNullOrWhiteSpace(mapping))
                return BadRequest();

            var red = MappingService.Read(mapping, string.IsNullOrWhiteSpace(variable)
                                            ? new[] { "This" }
                                            : Uri.UnescapeDataString(variable).Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries));

            if (red == null || !red.Any())
                return NotFound();
            return new ObjectResult(red);
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{mapping}")]
        [Produces(typeof(IDictionary<string,object>))]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public IActionResult Get(string mapping, [FromBody]params string[] variables)
        {
            if (string.IsNullOrWhiteSpace(mapping))
                return BadRequest();

            var red = MappingService.Read(mapping, variables == null || !variables.Any()
                                            ? new[] { "This" }
                                            : variables);

            if (red == null || !red.Any())
                return NotFound();
            return new ObjectResult(red);
        }


        /// <summary>
        /// Write some data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPatch("{mapping}")]
        //[Authorize(Policy = "ReadWritePolicy")]
        public IActionResult Patch(string mapping,[FromBody]Dictionary<string,object> value)
        {
            if (string.IsNullOrWhiteSpace(mapping) || value == null || !value.Any())
                return BadRequest();
            if (!MappingService.Write(mapping, value))
                return StatusCode((int)HttpStatusCode.NotModified);
            return new NoContentResult();
        }


        /// <summary>
        /// Write some data to a block
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="variable"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPatch("{mapping}/{variable}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public IActionResult Patch(string mapping, string variable, [FromBody]object value)
        {
            if (string.IsNullOrWhiteSpace(mapping) || string.IsNullOrWhiteSpace(variable) || value == null)
                return BadRequest();
            if(!MappingService.Write(mapping, new Dictionary<string, object>{ { variable, value } }))
                return StatusCode((int)HttpStatusCode.NotModified);
            return new NoContentResult();
        }


        /// <summary>
        /// Write full data to a block
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{mapping}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public IActionResult Put(string mapping, [FromBody]object value)
        {
            if (string.IsNullOrWhiteSpace(mapping) || value == null)
                return BadRequest();

            if(!MappingService.Write(mapping, new Dictionary<string, object> { { "This", value } }))
                return StatusCode((int)HttpStatusCode.NotModified);

            return new NoContentResult();
        }

    }
}
