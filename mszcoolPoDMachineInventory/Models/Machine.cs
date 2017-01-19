using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class Machine
    {
        public string Id { get; set; }
        public string EnvironmentId { get; set; }
        public string MachineName { get; set; }
        public string Description { get; set; }
        public string OwnerNameId { get; set; }
        public MachineTypes MachineType { get; set; }
        public MachineAdressDetails AddressDetails { get; set; }
        public List<PoDTaskDefinition> SupportedTasks { get; set; }
    }
}
