using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mszcoolPoDMachineInventory.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mszcoolPoDMachineInventory.Controllers
{
    [Route("api/machines/inventory")]
    public class MachinesInventoryController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<MachineEntry> Get()
        {
            return null;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public MachineEntry Get(string id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]MachineEntry machine)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]MachineEntry value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
