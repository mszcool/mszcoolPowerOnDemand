using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class MachineEntry
    {
        public string MachineId { get; set; }
        public string MachineName { get; set; }
        public string MachineDescription { get; set; }
        public string OwnerNameId { get; set; }
        public MachineTypes MachineType { get; set; }
        public IPAddress MachineIpAddress { get; set; }
        public IPAddress MachineIpSubnet { get; set; }
        public string MachineMacAddress { get; set; }
    }
}
