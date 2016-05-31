
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Interfaces;
using webpac.Services;

namespace webpac.Controllers
{
    [Route("api/[controller]")]
    public class AbsolutesController : BaseController
    {
        //[FromServices]
        public IMappingService MappingService { get; set; }

        public AbsolutesController(IMappingService mappingService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
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
        [Authorize(Policy = "ReadOnlyPolicy")]
        public object Get(string area, string address)
        {
            return MappingService.ReadAbs(area, address).Values.FirstOrDefault();
        }

        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{area}")]
        //[Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string, object> Get(string area, [FromBody]params string[] addresses)
        {
            return MappingService.ReadAbs(area, addresses);
        }


        /// <summary>
        /// Write a symbol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{area}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string area,[FromBody]Dictionary<string, object> value)
        {
            MappingService.WriteAbs(area, value);
        }

        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{area}/{variable}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string area, string address, [FromBody]object value)
        {
            MappingService.Write(area, new Dictionary<string, object> { { address, value } });
        }

    }
}
