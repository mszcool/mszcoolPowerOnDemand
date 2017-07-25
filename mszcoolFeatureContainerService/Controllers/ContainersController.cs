using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mszcoolFeatureContainerService.Controllers
{
    [Route("api/[controller]")]
    public class ContainersController : Controller
    {
        [HttpPost]
        public void AddNewContainer(string imageName)
        {

        }

        [HttpPut]
        public string StartContainer(string containerId)
        {
            return null;
        }

        [HttpPut]
        public void StopContainer(string containerId)
        {

        }

        [HttpDelete]
        public void DeleteContainer(string containerId)
        {

        }
    }
}
