using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class PoDDevice
    {
        public string DeviceName { get; set; }
        public string DeviceDisplayName { get; set; }
        public object DeviceSpecifics { get; set; }
    }
}
