using System;
using System.Collections.Generic;
using System.Linq;
using webpac.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webpac.Controllers
{
    [Route("api/[controller]")]
    public class SymbolicController : BaseController
    {
        //[FromServices]
        public IMappingService MappingService { get; set; }

        public SymbolicController(IMappingService mappingService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
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
        [HttpGet("{id}/{variable}")]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string,object> Get(string id, string variable = null)
        {
            return MappingService.Read(id, string.IsNullOrWhiteSpace(variable)
                                            ? new[] { "This" }
                                            : Uri.UnescapeDataString(variable).Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string, object> Get(string id, params string[] variables)
        {
            return MappingService.Read(id, !variables.Any()
                                            ? new[] { "This" }
                                            : variables);
        }


        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string id,[FromBody]Dictionary<string,object> value)
        {
            MappingService.Write(id, value);
        }


        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}/{variable}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string id, string variable, [FromBody]object value)
        {
            MappingService.Write(id, new Dictionary<string, object>{ { variable, value } });
        }

    }
}
