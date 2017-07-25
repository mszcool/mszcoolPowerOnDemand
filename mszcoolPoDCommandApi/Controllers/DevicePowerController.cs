using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mszcoolPoDCommandApi.Controllers
{
    [Route("api/[controller]/{environmentName}")]
    public class DevicePowerController : Controller
    {
        [HttpGet]
        public Dictionary<string, string> GetDeviceStatus(string environmentName)
        {
            return null;
        }

        [HttpGet("{agentName}")]
        public Dictionary<string, string> GetDeviceStatus(string environmentName, string agentName)
        {
            return null;
        }

        [HttpGet("{agentName}/{deviceName}")]
        public string GetDeviceStatus(string environmentName, string agentName, string deviceName)
        {
            return null;
        }

        [HttpPost("{agentName}/{deviceName}/on")]
        public void PowerOnDevice(string environmentName, string agentName, string deviceName)
        {

        }

        [HttpPost("{agentName}/{deviceName}/off")]
        public void PowerOffDevice(string environmentName, string agentName, string deviceName)
        {

        }
    }
}
