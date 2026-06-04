using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Nabd.Core.Entities.Identity;

namespace Nabd.Infrastructure.Seeders
{
    public static class RoleSeed
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            string[] roles = { "Admin", "Patient", "Doctor", "Verifier" };

            Console.WriteLine("Seeding Roles...");

            foreach (var roleName in roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new Role { Name = roleName });
                    Console.WriteLine($"Role '{roleName}' created.");
                }
            }
            Console.WriteLine("Roles seeding completed.");
        }
    }
}
