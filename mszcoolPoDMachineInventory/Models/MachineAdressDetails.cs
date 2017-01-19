using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class MachineAdressDetails
    {
        public IPAddress InternalIpAddress { get; set; }
        public IPAddress InternalIpSubnet { get; set; }
        public IPAddress PublicIpAddress { get; set; }
        public DnsEndPoint PublicDnsName { get; set; }
        public string MacAddress { get; set; }
    }
}
