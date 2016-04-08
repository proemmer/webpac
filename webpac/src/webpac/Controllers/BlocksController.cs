using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using webpac.Services;

namespace webpac.Controllers
{
    [Route("api/[controller]")]
    public class BlocksController : Controller
    {
        [FromServices]
        public IMappingService MappingService { get; set; }


        /// <summary>
        /// Get List of blocks
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
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
        public Dictionary<string,object> Get(string id, string variable = "")
        {
            return MappingService.Read(id, variable.Split(new []{ "," },StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Add a mapping
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
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
        public void Delete(int id)
        {
        }
    }
}
