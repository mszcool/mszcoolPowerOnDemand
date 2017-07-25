using Microsoft.AspNetCore.Mvc;
using mszcoolPoDInventoryApi.Models;
using mszcoolPoDMachineInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Controllers
{
    // TODO: check how to best do this route with least overhead
    [Route("api/environments/{environmentName}")]
    public class DeviceAgentsController : Controller
    {
        [HttpGet()]
        public void GetAgents(string environmentName)
        {

        }

        [HttpGet("{agentName}")]
        public void GetAgentDevices(string environmentName, string agentName)
        {

        }

        [HttpPost()]
        public void RequestAgentOnboarding(string environmentName, PoDDeviceAgent agent)
        {

        }

        [HttpPost("{agentName}/approval")]
        public void ApproveAgentOnboarding(string environmentName, string agentName, PoDDeviceAgentApproval agentApproval)
        {

        }

        [HttpDelete("{agentName}")]
        public void RemoveAgent(string environmentName, string agentName)
        {

        }
    }
}
