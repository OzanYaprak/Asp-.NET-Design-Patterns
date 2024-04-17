using DesignPattern.Mediator.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Mediator.Data
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;initial catalog=Mediator; integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }
    }
}
