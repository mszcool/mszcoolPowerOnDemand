using Microsoft.AspNetCore.Mvc;
using mszcoolPoDMachineInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Controllers
{
    // TODO: check how to best do this route with least overhead
    [Route("api/environments/{environmentId}/machines")]
    public class MachinesController : Controller
    {
        [HttpGet("{machineId}")]
        public Machine Get(string environmentId, string machineId)
        {
            return null;
        }

        [HttpPost()]
        public void Post(string environmentId, [FromBody]Machine machine)
        {

        }

        [HttpPut("{machineId}")]
        public void Put(string environmentId, string machineId, [FromBody]Machine machine)
        {

        }

        [HttpDelete("{machineId}")]
        public void Delete(string environmentId, string machineId)
        {

        }
    }
}
