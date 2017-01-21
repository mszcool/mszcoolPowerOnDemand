using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineTasks.Controllers
{
    [Route("api/tasks")]
    public class MachineTasksController : Controller
    {
        // Allows the execution of explicitly pre-defined tasks for a machine - defined by the agent
        // /api/tasks/{environmentId}/{machineId}/{task}?param=value&param=value&param=value
        [HttpPost("{environmentId}/{machineId}/{task}")]
        public void ExecuteDefinedTask(string environmentId, string machineId, string task, [FromQuery]IDictionary<string, string> additionalParameters)
        {

        }
    }
}
