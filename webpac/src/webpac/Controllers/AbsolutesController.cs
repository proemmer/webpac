
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
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Policy = "ReadOnlyPolicy")]
        public object Get(string id)
        {
            return MappingService.Read(id,"").Values.FirstOrDefault();
        }

        /// <summary>
        /// Add a Symbol
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        [Authorize(Policy = "AdministrationPolicy")]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Write a symbol
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Remove a symbol
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministrationPolicy")]
        public void Delete(int id)
        {
        }
    }
}
