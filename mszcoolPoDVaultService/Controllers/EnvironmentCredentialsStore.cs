using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mszcoolPoDVaultService.Controllers
{
    [Route("api/[controller]")]
    public class EnvironmentCredentialsStore : Controller
    {
        [HttpGet]
        public Dictionary<string, string> GetCredentials(string environmentName)
        {
            return null;
        }

        [HttpPost]
        public string CreateCredentials(string environmentName, [FromBody]Dictionary<string, string> credentials)
        {
            return null;
        }

        [HttpPut]
        public void UpdateCredentials(string environmentName, string credentialsId, [FromBody]Dictionary<string, string> credentials)
        {

        }

        [HttpDelete]
        public void RemoveCredentials(string environmentName, string credentialsId)
        {

        }
    }
}
