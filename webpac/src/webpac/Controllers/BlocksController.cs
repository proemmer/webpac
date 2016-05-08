using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using webpac.Services;
using Microsoft.Extensions.Logging;
using webpac.Interfaces;
using Microsoft.AspNet.Authorization;

namespace webpac.Controllers
{
    [Route("api/[controller]")]
    public class BlocksController : BaseController
    {
        [FromServices]
        public IMappingService MappingService { get; set; }


        /// <summary>
        /// Get List of blocks
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [Authorize(Policy = "ReadOnlyPolicy")]
        public IEnumerable<string> Get()
        {
            return MappingService.GetSymbolicBlocks();
        }

        
        /// <summary>
        /// Read a block
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}/{variable}")]
        [Authorize(Policy = "ReadOnlyPolicy")]
        public Dictionary<string,object> Get(string id, string variable = "")
        {
            return MappingService.Read(id, string.IsNullOrWhiteSpace(variable) 
                                            ? new[] { "This" } 
                                            : variable.Split(new []{ "," },StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Add a mapping
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        [Authorize(Policy = "AdministrationPolicy")]
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Write data to a block
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize(Policy = "ReadWritePolicy")]
        public void Put(string id, [FromBody]Dictionary<string,object> value)
        {
            MappingService.Write(id, value);
        }

        /// <summary>
        /// Remove a mapping
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
