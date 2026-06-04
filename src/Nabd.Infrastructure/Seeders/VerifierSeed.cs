using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums.Identity;
using Nabd.Infrastructure.Data;

namespace Nabd.Infrastructure.Seeders
{
    public static class VerifierSeed
    {
        private const string DefaultPassword = "Test@123";

        public static async Task SeedAsync(NabdDbContext context, UserManager<User> userManager)
        {
            // Cleanup old verifier if exists
            var oldUser = await userManager.FindByEmailAsync("ahmed.verifier@shuryan.com");
            if (oldUser != null)
            {
                Console.WriteLine("Found old verifier 'ahmed.verifier@shuryan.com'. Attempting to remove...");
                try 
                {
                    await userManager.DeleteAsync(oldUser);
                    Console.WriteLine("Old verifier removed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not delete old verifier (likely due to foreign key constraints): {ex.Message}");
                    Console.WriteLine("Deactivating old verifier account instead...");
                    
                    oldUser.Email = $"deleted_ahmed_{Guid.NewGuid()}@shuryan.com";
                    oldUser.UserName = oldUser.Email;
                    oldUser.NormalizedEmail = oldUser.Email.ToUpper();
                    oldUser.NormalizedUserName = oldUser.UserName.ToUpper();
                    oldUser.PasswordHash = "INVALID_HASH";
                    oldUser.LockoutEnabled = true;
                    oldUser.LockoutEnd = DateTimeOffset.MaxValue;
                    
                    await userManager.UpdateAsync(oldUser);
                    Console.WriteLine("Old verifier deactivated.");
                }
            }

            // Define expected verifiers
            var adminId = Guid.NewGuid(); // Simulated admin ID
            var verifiersList = new List<(Verifier verifier, string password)>
            {
                (new Verifier
                {
                    FirstName = "زكريا",
                    LastName = "نبض",
                    Email = "zakaria@nabd.com",
                    UserName = "zakaria@nabd.com",
                    PhoneNumber = "+201001234567",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                }, "Zak123#"), // Custom password for this user
                (new Verifier
                {
                    FirstName = "فاطمة",
                    LastName = "السيد",
                    Email = "fatma.verifier@shuryan.com",
                    UserName = "fatma.verifier@shuryan.com",
                    PhoneNumber = "+201002345678",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                }, DefaultPassword),
                (new Verifier
                {
                    FirstName = "محمد",
                    LastName = "حسن",
                    Email = "mohamed.verifier@shuryan.com",
                    UserName = "mohamed.verifier@shuryan.com",
                    PhoneNumber = "+201003456789",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    CreatedByAdminId = adminId
                }, DefaultPassword)
            };

            Console.WriteLine("Seeding Verifiers...");

            foreach (var (verifierData, password) in verifiersList)
            {
                // Check if user exists
                var existingUser = await userManager.FindByEmailAsync(verifierData.Email);
                
                // If user exists, verify password. If incorrect, delete and recreate.
                if (existingUser != null)
                {
                    var checkPass = await userManager.CheckPasswordAsync(existingUser, password);
                    if (!checkPass)
                    {
                        Console.WriteLine($"Password mismatch for {verifierData.Email}. Deleting user to recreate with correct credentials...");
                        await userManager.DeleteAsync(existingUser);
                        existingUser = null; // Mark as null to trigger creation
                    }
                }

                if (existingUser == null)
                {
                    // Create new user (or recreate after deletion)
                    var result = await userManager.CreateAsync(verifierData, password);
                    if (result.Succeeded)
                    {
                        Console.WriteLine($"Verifier created: {verifierData.Email}");
                        await userManager.AddToRoleAsync(verifierData, "Verifier");
                        Console.WriteLine($"Role 'Verifier' assigned to: {verifierData.Email}");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to create verifier {verifierData.Email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                    }
                }
                else
                {
                    // User exists and password is correct, just ensure role
                    if (!await userManager.IsInRoleAsync(existingUser, "Verifier"))
                    {
                        await userManager.AddToRoleAsync(existingUser, "Verifier");
                        Console.WriteLine($"Role 'Verifier' assigned to existing user: {verifierData.Email}");
                    }
                }
            }

            Console.WriteLine("Verifiers seeding verification completed.");
        }
    }
}