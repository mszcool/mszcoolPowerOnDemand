using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class PoDTaskDefinition
    {
        public string DefinitionNr { get; set; }
        public string TaskName { get; set; }
        public List<string> TaskParameters { get; set; }
    }
}
