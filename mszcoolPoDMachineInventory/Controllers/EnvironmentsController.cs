﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mszcoolPoDMachineInventory.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mszcoolPoDMachineInventory.Controllers
{
    [Route("api/environments")]
    public class EnvironmentsController : Controller
    {
        // GET: api/environments
        [HttpGet]
        public IEnumerable<Machine> Get()
        {
            return null;
        }

        // GET api/environments/{environmentName}
        [HttpGet("{environmentName}")]
        public Machine Get(string environmentName)
        {
            return null;
        }

        // POST api/environments
        [HttpPost]
        public void Post([FromBody]PoDEnvironment environment)
        {
        }

        // PUT api/environments
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]PoDEnvironment environment)
        {
        }

        // DELETE api/environments/238729-234234-4327682-32432
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}