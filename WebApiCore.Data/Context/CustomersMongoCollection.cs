using System;
using System.Collections.Generic;
using MongoDB.Driver;
using WebApiCore.Data.Models;
using System.Linq.Expressions;

namespace WebApiCore.Data.Context
{
   public class CustomersMongoCollection
   {

      private readonly IMongoCollection<Customer> _customers;
      public CustomersMongoCollection(IMongoCollection<Customer> _customers)
      {
         this._customers;
      }

      public List<Customer> ToList() =>
         _customers.Find(Customer => true).ToList();

      public List<Customer> Get(string id) =>
         _customers.Find<Customer>(Customers => Customers.Id == id).FirstOrDefault();

      public CustomersMongoCollection FirstOrDefault(Expression<Func<Customers, bool>> predicator) =>
         _customers.Find<Customer>(predicator).FirstOrDefault();

      public CustomersMongoCollection Add(Customer Customer)
      {
         _customers.InsertOne(Customer);
         return Customer;
      }

      public void Update(Customer Customer) =>
         _customers.ReplaceOne(Customer => Customer.Id == CustomerIn.Id, CustomerIn);
   }
}