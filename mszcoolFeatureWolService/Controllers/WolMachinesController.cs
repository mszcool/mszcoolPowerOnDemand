using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mszcoolFeatureWolService.Controllers
{
    [Route("api/[controller]")]
    public class WolMachinesController : Controller
    {
        [HttpPost]
        public void AddMachine(string machineIp, string machineIpSubnet, string machineMacAddress)
        {

        }

        [HttpPut]
        public string StartMachine(string machineIp, string machineIpSubnet, string machineMacAddress)
        {
            return null;
        }

        [HttpPut]
        public void StopMachine(string machineIp, string machineIpSubnet, string machineMacAddress)
        {

        }

        [HttpDelete]
        public void RemoveMachine(string machineIp, string machineIpSubnet, string machineMacAddress)
        {

        }
    }
}
