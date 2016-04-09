﻿using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webpac.Interfaces;
using webpac.Services;

namespace webpac.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SymbolsController : BaseController
    {
        [FromServices]
        public IMappingService MappingService { get; set; }


        /// <summary>
        /// Get List of Symbols
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "ReadOnlyPolicy")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        /// <summary>
        /// Read a Symbol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize(Roles = "ReadOnlyPolicy")]
        public string Get(int id)
        {

            return "value";
        }

        /// <summary>
        /// Add a Symbol
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        [Authorize(Roles = "AdministrationPolicy")]
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
        [Authorize(Roles = "ReadWritePolicy")]
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Remove a symbol
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "AdministrationPolicy")]
        public void Delete(int id)
        {
        }
    }
}