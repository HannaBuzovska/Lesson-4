using System;
using Microsoft.EntityFrameworkCore;

namespace WebApiCore.Data.Context
{
   public class WebApiCoreContext : DbContext
{
    public DbSet<Customer> Customers {get;set;}

    public DbSet<CurrentWeather> Weathers {get; set; }

   public WebApiCoreContext(DbContextOptions<WebApiCoreContext> options) : base(options)
   {
   }
   protected override void OnConfiguring(DbContextBuilder optionsBuilder){ }
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      //modelBuilder.Entity<Customer>().HasData(new Customer{Id = 1, nameof = "Nick", BirthDate = DateTime(2000, 01, 01)});
      //modelBuilder.Entity<Customer>().HasData(new Customer{Id = 2, nameof = "Nick", BirthDate = DateTime(1980, 01, 01)});
   }
}
}