using Microsoft.EntityFrameworkCore;

namespace DesignPattern.CQRS.DAL
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;initial catalog=DbCQRSDesignPattern; integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }
    }
}
