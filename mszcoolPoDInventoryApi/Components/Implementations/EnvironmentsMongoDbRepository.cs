using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mszcoolPoDMachineInventory.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace mszcoolPoDInventoryApi.Components.Implementations
{
    public class EnvironmentsMongoDbRepository : IEnvironmentsRepository
    {
        private MongoClient _mongoDbClient;
        private string _mongoDbConnectionString = string.Empty;

        public EnvironmentsMongoDbRepository(IConfiguration config)
        {
            _mongoDbConnectionString = config.GetValue<string>(Constants.MongoDbConnectionStringSettingName);
            if (string.IsNullOrEmpty(_mongoDbConnectionString))
            {
                throw new Exception($"Missing connection string configuration '{Constants.MongoDbConnectionStringSettingName}' for MongoDB!");
            }
            else
            {
                try
                {
                    _mongoDbClient = new MongoClient(_mongoDbConnectionString);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed instantiating MongoClient, please verify connection string!", ex);
                }
            }
        }

        #region IEnvironmentsRepository

        public void AddEnvironment(PoDEnvironment newEnvironment)
        {
            try
            {
                var collection = GetEnvironmentsCollection();
                collection.InsertOne(newEnvironment);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed adding new environment to system.", ex);
            }
        }

        public PoDEnvironment GetEnvironment(string environmentName)
        {
            try
            {
                var collection = GetEnvironmentsCollection();
                var result = collection.Find(filter => filter.EnvironmentName == environmentName).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed retrieving existing environment from system.", ex);
            }
        }

        public IList<PoDEnvironment> GetEnvironments(string ownerNameId)
        {
            try
            {
                var collection = GetEnvironmentsCollection();
                var results = collection.Find(filter => filter.EnvironmentOwnerNameId == ownerNameId);
                return results.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed retrieving existing environments from system.", ex);
            }
        }

        public void UpdateEnvironment(PoDEnvironment updatedEnvironment)
        {
            try
            {
                var collection = GetEnvironmentsCollection();

                var filterDef = new ExpressionFilterDefinition<PoDEnvironment>(d => d.EnvironmentName == updatedEnvironment.EnvironmentName);
                var updateDef = new ObjectUpdateDefinition<PoDEnvironment>(updatedEnvironment);

                var result = collection.UpdateOne(filterDef, updateDef);

                if (result.MatchedCount == 0)
                    throw new Exception("Record not found!");
                if (result.ModifiedCount == 0)
                    throw new Exception("No records updated!");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed updating existing environment in system.", ex);
            }
        }

        public void DeleteEnvironment(string environmentName)
        {
            try
            {
                var collection = GetEnvironmentsCollection();

                var filterDef = new ExpressionFilterDefinition<PoDEnvironment>(d => d.EnvironmentName == environmentName);

                var results = collection.DeleteOne(filterDef);

                if (results.DeletedCount == 0)
                    throw new Exception("No records where deleted!");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed deleting existing environment from system.", ex);
            }
        }

        #endregion

        #region Private Helper Methods

        private IMongoCollection<PoDEnvironment> GetEnvironmentsCollection()
        {
            var db = _mongoDbClient.GetDatabase(Constants.MongoDbDatabaseName);
            var collection = db.GetCollection<PoDEnvironment>(
                                Constants.MongoDbCollectionEnvironments,
                                new MongoCollectionSettings
                                {
                                    AssignIdOnInsert = false,
                                    GuidRepresentation = MongoDB.Bson.GuidRepresentation.Standard,
                                    ReadConcern = ReadConcern.Default,
                                    WriteConcern = WriteConcern.WMajority
                                }
                            );
            return collection;
        }

        #endregion
    }
}
