using Microsoft.AspNetCore.Mvc;
using mszcoolPoDMachineInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Controllers
{
    [Route("api/environments/{environmentId}/machines/{machineId}/tasks")]
    public class TasksController : Controller
    {
        [HttpGet()]
        public List<PoDTaskDefinition> Get(string environmentId, string machineId)
        {
            return null;
        }

        [HttpPost]
        public void Execute(string environmentId, string machineId, [FromBody]PoDTaskDefinition task)
        {

        }
    }
}
