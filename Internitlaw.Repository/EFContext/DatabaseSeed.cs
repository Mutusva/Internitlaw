using System.Collections.Generic;
using System.Linq;
using Internitlaw.Domain.Models;

namespace Internitlaw.Repository.EFContext
{
    public class DatabaseSeed
	{
        public static void Seed(InternitlawContext context)
        {
            context.Database.EnsureCreated();

            if (context.Role.Count() == 0)
            {

                var roles = new List<Role>
                {
                new Role { Name = ApplicationRole.Employee.ToString() },
                new Role { Name = ApplicationRole.Security.ToString() },
                new Role { Name = ApplicationRole.HR.ToString() },
                new Role { Name = ApplicationRole.Administrator.ToString() }
                };

                context.Role.AddRange(roles);
                context.SaveChanges();
            }            
        }
    }
}
