using Microsoft.EntityFrameworkCore;
using Internitlaw.Domain.Models;

namespace Internitlaw.Repository.EFContext
{
	public class InternitlawContext : DbContext
	{
		public InternitlawContext(DbContextOptions<InternitlawContext> options) : base(options) { }

		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<UserRole> UserRole { get; set; }
		public virtual DbSet<Role> Role { get; set; }
	
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.AddModelEntities();			
		}
	}
}
