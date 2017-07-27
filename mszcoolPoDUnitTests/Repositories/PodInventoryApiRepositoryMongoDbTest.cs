using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using mszcoolPoDInventoryApi.Models;
using mszcoolPoDInventoryApi.Components;
using mszcoolPoDInventoryApi.Components.Implementations;
using Microsoft.Extensions.Configuration;
using mszcoolPoDMachineInventory.Models;
using MongoDB.Driver;

namespace mszcoolPoDUnitTests.Repositories
{
    [TestClass]
    public class PodInventoryApiRepositoryMongoDbTest
    {
        private MongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<PoDEnvironment> _environmentsCollection;

        private IConfiguration _config;
        private string _mongoDbConnectionString = string.Empty;

        private static readonly string[] EnvironmentTestOwnersData =
        {
            "owner#1",
            "owner#2",
            "owner#3"
        };

        private static readonly List<PoDEnvironment> EnvironmentTestBaseData = new List<PoDEnvironment>
        {
            new PoDEnvironment { EnvironmentName = "env01", EnvironmentDisplayName = "Environment 01", EnvironmentOwnerNameId = EnvironmentTestOwnersData[0], BaseUrl = "http://localhost:1" },
            new PoDEnvironment { EnvironmentName = "env02", EnvironmentDisplayName = "Environment 02", EnvironmentOwnerNameId = EnvironmentTestOwnersData[0], BaseUrl = "http://localhost:2" },
            new PoDEnvironment { EnvironmentName = "env03", EnvironmentDisplayName = "Environment 03", EnvironmentOwnerNameId = EnvironmentTestOwnersData[1], BaseUrl = "http://localhost:3" },
            new PoDEnvironment { EnvironmentName = "env04", EnvironmentDisplayName = "Environment 04", EnvironmentOwnerNameId = EnvironmentTestOwnersData[1], BaseUrl = "http://localhost:4" },
            new PoDEnvironment { EnvironmentName = "env05", EnvironmentDisplayName = "Environment 05", EnvironmentOwnerNameId = EnvironmentTestOwnersData[2], BaseUrl = "http://localhost:5" }
        };

        private static readonly List<PoDEnvironment> EnvironmentTestDynamicData = new List<PoDEnvironment>
        {
            new PoDEnvironment { EnvironmentName = "d__env01", EnvironmentDisplayName = "d__Environment 01", EnvironmentOwnerNameId = EnvironmentTestOwnersData[0], BaseUrl = "http://localhost:1/dynamic1" },
            new PoDEnvironment { EnvironmentName = "d__env02", EnvironmentDisplayName = "d__Environment 02", EnvironmentOwnerNameId = EnvironmentTestOwnersData[1], BaseUrl = "http://localhost:2/dynamic2" },
            new PoDEnvironment { EnvironmentName = "d__env03", EnvironmentDisplayName = "d__Environment 03", EnvironmentOwnerNameId = EnvironmentTestOwnersData[2], BaseUrl = "http://localhost:3/dynamic3" },
            new PoDEnvironment { EnvironmentName = "d__env04", EnvironmentDisplayName = "d__Environment 04", EnvironmentOwnerNameId = EnvironmentTestOwnersData[0], BaseUrl = "http://localhost:4/dynamic4" }
        };

        private IEnvironmentsRepository CreateTestee()
        {
            return new EnvironmentsMongoDbRepository(_config);
        }

        #region Test Initialization and Cleanup

        [TestInitialize]
        public void Init()
        {
            _mongoDbConnectionString = Environment.GetEnvironmentVariable(Constants.MongoDbConnectionStringSettingName);
            if (_mongoDbConnectionString == null)
            {
                _mongoDbConnectionString = "mongodb://localhost:27017";
                Environment.SetEnvironmentVariable(Constants.MongoDbConnectionStringSettingName, _mongoDbConnectionString);
            }

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddEnvironmentVariables();
            _config = builder.Build();

            _client = new MongoClient(_mongoDbConnectionString);
            _database = _client.GetDatabase(Constants.MongoDbDatabaseName);

            // Ensure that all data items are deleted
            _database.DropCollection(Constants.MongoDbCollectionEnvironments);
            _environmentsCollection = _database.GetCollection<PoDEnvironment>(Constants.MongoDbCollectionEnvironments);

            // Insert the base data that's assumed to be present for running the tests
            _environmentsCollection.InsertMany(EnvironmentTestBaseData);
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        #endregion

        #region Test Methods for Environments

        [TestMethod]
        [TestCategory("Repositories.Environment")]
        public void TestEnvironmentInsert()
        {
            var testee = CreateTestee();

            // Insert all elements into the database
            foreach (var item in EnvironmentTestDynamicData)
            {
                testee.AddEnvironment(item);
            }

            // Now get all items manually using the MongoDB SDK
            var foundItems = 0L;
            var environmentsCollection = _database.GetCollection<PoDEnvironment>(Constants.MongoDbCollectionEnvironments);
            if(environmentsCollection != null)
            {
                foreach (var item in EnvironmentTestDynamicData)
                {
                    var filterDef = new ExpressionFilterDefinition<PoDEnvironment>(f => f.EnvironmentName == item.EnvironmentName);
                    var result = environmentsCollection.Find(filterDef);
                    foundItems += result.Count();
                }
            }
            var overallCount = environmentsCollection.Count(new MongoDB.Bson.BsonDocument());

            // Test assertions
            Assert.IsNotNull(environmentsCollection, $"Insert failed because the collection {Constants.MongoDbCollectionEnvironments} does not exist!");
            Assert.AreEqual(foundItems, EnvironmentTestDynamicData.Count);
            Assert.AreEqual(overallCount, EnvironmentTestBaseData.Count + EnvironmentTestDynamicData.Count);
        }

        [TestMethod]
        [TestCategory("Repositories.Environment")]
        public void TestEnvironmentGetSingle()
        {
            var testee = CreateTestee();

            var targetTestItemIdx = new Random().Next(0, EnvironmentTestBaseData.Count - 1);
            var foundToBe = EnvironmentTestBaseData[targetTestItemIdx];

            var foundActual = testee.GetEnvironment(foundToBe.EnvironmentName);

            Assert.IsNotNull(foundActual, $"Environment with name {foundToBe.EnvironmentName} not found although should be in database!");
            Assert.AreEqual(foundActual.EnvironmentName, foundToBe.EnvironmentName);
            Assert.AreEqual(foundActual.EnvironmentDisplayName, foundToBe.EnvironmentDisplayName);
        }

        [TestMethod]
        [TestCategory("Repositories.Environment")]
        public void TestEnvironmentGetMultiple()
        {
            var testee = CreateTestee();

            var targetOwnerIdx = new Random().Next(0, EnvironmentTestOwnersData.Length - 1);
            var targetOwner = EnvironmentTestOwnersData[targetOwnerIdx];

            var expected = EnvironmentTestBaseData.Where(e => e.EnvironmentOwnerNameId == targetOwner);

            var actual = testee.GetEnvironments(targetOwner);

            Assert.AreEqual(expected.Count(), actual.Count());
            foreach (var expectedItem in expected)
            {
                Assert.IsNotNull(actual.Select(a => a.EnvironmentName == expectedItem.EnvironmentName));
            }
        }

        #endregion
    }
}
