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
        [HttpGet("{mapping}/{variable}")]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string,object> Get(string mapping, string variable = null)
        {
            return MappingService.Read(mapping, string.IsNullOrWhiteSpace(variable)
                                            ? new[] { "This" }
                                            : Uri.UnescapeDataString(variable).Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{mapping}")]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string, object> Get(string mapping, [FromBody]params string[] variables)
        {
            return MappingService.Read(mapping, !variables.Any()
                                            ? new[] { "This" }
                                            : variables);
        }


        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{mapping}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string mapping,[FromBody]Dictionary<string,object> value)
        {
            MappingService.Write(mapping, value);
        }


        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{mapping}/{variable}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string mapping, string variable, [FromBody]object value)
        {
            MappingService.Write(mapping, new Dictionary<string, object>{ { variable, value } });
        }

    }
}
