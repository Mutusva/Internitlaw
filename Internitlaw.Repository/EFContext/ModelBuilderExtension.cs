using Microsoft.EntityFrameworkCore;
using Internitlaw.Domain.Models;

namespace Internitlaw.Repository.EFContext
{
	public static class ModelBuilderExtension
	{
		public static ModelBuilder AddModelEntities(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("user", "internitlaw");
				entity.HasKey(p => p.Id);
			});

			modelBuilder.Entity<Role>(entity =>
			{
				entity.ToTable("role", "internitlaw");
				entity.HasKey(p => p.Id);
				entity.HasData(
					 new Role { Id = 1, Name = "Employee", Description = "normal Employee" },
					 new Role { Id = 2, Name = "Security", Description = "Security Personel" }
					); ;
			});			

			return modelBuilder;
		}
	}
}
