using System.Collections.Generic;
using MongoDB.Driver;
using WebApiCore.Data.Models;

namespace WebApiCore.Data.Context
{
   public class MongoContext
   {
      public CustomersMongoCollection Customers {get; private set;}
      public MongoContext(MongoDBSettings settings)
      {
         var client = new MongoClient(settings.ConnectionString);
         var database = client.GetDatabase(settings.DatabaseName);

         Customers = new CustomersMongoCollection(database.GetCollection<Customer>(settings.CustomerCollectionName));
      }
   }
}