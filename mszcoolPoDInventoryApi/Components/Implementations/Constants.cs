using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mszcoolPoDInventoryApi.Components.Implementations
{
    public class Constants
    {
        public const string MongoDbDatabaseName = "DevicesInventory";
        public const string MongoDbCollectionEnvironments = "Environments";
        public const string MongoDbConnectionStringSettingName = "Repositories.Environments.MongoDbConnection";

    }
}
