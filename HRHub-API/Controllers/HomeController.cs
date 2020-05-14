﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRHub_API.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRHub_API.Controllers  
{
    

  
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ILoggerService _logger;


        public HomeController(ILoggerService logger)
        {
            _logger = logger;

        }

        /// <summary>
        /// THis is a test controller
        /// </summary>
        // GET: api/Home
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Acceesed HomeController");
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets int value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            _logger.LogDebug("Got a Value");
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
            _logger.LogError("Error");
        }


        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogWarn("Got a Warrning");
        }
    }
}
