using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineTasks.Controllers
{
    [Route("api/power")]
    public class MachinePowerController : Controller
    {
        // /api/tasks/{environmentId}/{machineId}/wakeup
        public void Wakeup(string environmentId, string machineId)
        {

        }

        // /api/tasks/{environmentId}/{machineId}/shutdown
        public void Shutdown(string environmentId, string machineId, [FromQuery]IDictionary<string, string> additionalParameters)
        {

        }      
    }
}
