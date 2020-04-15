
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Numero3.EntityFramework.Demo.DomainModel;

namespace Numero3.EntityFramework.Demo.DatabaseContext
{
	public class UserManagementDbContext : DbContext
	{
		// Map our 'User' model by convention
		public DbSet<User> Users { get; set; }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
　　　　　　//SslModel=None 这和ssl协议有关系。如果不指定会报错
            optionsBuilder.UseMySql("Data Source=192.168.200.60;Database=usermgt;User ID=uoko;Password=MdmgKSFdUZwK;pooling=true;CharSet=utf8;port=3336;sslmode=Preferred");
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Overrides for the convention-based mappings.
			// We're assuming that all our fluent mappings are declared in this assembly.
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserManagementDbContext)));
		}
	}
}
