using DesignPattern.Facade.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Facade.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;initial catalog=Facade; integrated security=true;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
