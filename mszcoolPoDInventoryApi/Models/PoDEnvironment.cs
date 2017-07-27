using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDMachineInventory.Models
{
    public class PoDEnvironment
    {
        [BsonId]
        public string EnvironmentName { get; set; }
        public string EnvironmentDisplayName { get; set; }
        public string BaseUrl { get; set; }
        public string EnvironmentOwnerNameId { get; set; }
    }
}
