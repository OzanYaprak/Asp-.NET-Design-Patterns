using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern.ChainOfResponsibility.Data
{
	public class DBContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;initial catalog=DbChainOfResDesignPattern; integrated security=true;");
		}
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
