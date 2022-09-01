using Bank.Data.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Data.Context
{
    public class MongoDbClient : IMongoDbClient
    {
        public MongoDbClient(IOptions<MongoDbConfig> mongoDbConfig)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            //var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(mongoDbConfig.Value.Database_Name);
        }
    }
}
