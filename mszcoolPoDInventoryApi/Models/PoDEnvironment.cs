using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class PoDEnvironment
    {
        public string Id { get; set; }
        public string EnvironmentName { get; set; }
        public string BaseUrl { get; set; }
        public string EnvironmentOwnerNameId { get; set; }
        public PodEnvironmentCredentialsSource CredentialsSource { get; set; }
        public byte[] Credentials { get; set; }
    }
}
