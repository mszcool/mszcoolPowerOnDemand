using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mszcoolFeaturePowerPlugService.Controllers
{
    [Route("api/[controller]")]
    public class PowerPlugsController : Controller
    {
        [HttpPost]
        public void AddPowerPlug(string plugName, string plugFrequency)
        {

        }

        [HttpPut]
        public string PowerOnPowerPlug(string plugName)
        {
            return null;
        }

        [HttpPut]
        public void PowerOffPowerPlug(string plugName)
        {

        }

        [HttpDelete]
        public void RemovePowerPlug(string plugName)
        {

        }
    }
}
