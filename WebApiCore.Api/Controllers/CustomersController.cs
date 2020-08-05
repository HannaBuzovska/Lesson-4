using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using WebApiCore.Api;
using WebApiCore.Data.Models;

namespace WebApeCore.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class CustomersController : ControllerBase
   {
      public IRepository<Customer> contextCustomers { get; private set; }
      
      public CustomersController(
         IRepository<Customer> contextCustomers
      )
      {
         this.contextCustomers = contextCustomers;

         //IRepository<Customer> _repo = IoCContainer.Resolve<IRepository<Customer>>();
         //this.contextCustomers = _repo;
      }

      [HttpGet]
      public IEnumerable<Customer> Get()
      {
         return contextCustomers.All;
      }

      [HttpGet("{id}")]
      public ActionResult<Customer> Get(int id)
      {
         return new contextCustomers.FindById(id);
      }

      [HttpPost]
      public void Post([FromQuery] CustomersController value)
      {
         contextCustomers.Update(value);
      }

      [HttpPut("{id}")]
      public void Put(int Id, [FromBody] CustomersController value)
      {
         var entity = contextCustomers.FindById(id);
         contextCustomers.Delete(entity);
      }

      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   } 
}