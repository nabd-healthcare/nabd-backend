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
                }, "Zakaria@123") // Fixed password, at least 8 characters
            };

            Console.WriteLine("Seeding Verifiers...");

            foreach (var (verifierData, password) in verifiersList)
            {
                // Check if user exists
                var existingUser = await userManager.FindByEmailAsync(verifierData.Email);
                
                // If user exists, verify password. If incorrect, update password.
                if (existingUser != null)
                {
                    var checkPass = await userManager.CheckPasswordAsync(existingUser, password);
                    if (!checkPass)
                    {
                        Console.WriteLine($"Password mismatch for {verifierData.Email}. Resetting password...");
                        var token = await userManager.GeneratePasswordResetTokenAsync(existingUser);
                        var resetResult = await userManager.ResetPasswordAsync(existingUser, token, password);
                        if (!resetResult.Succeeded)
                        {
                            Console.WriteLine($"Failed to reset password: {string.Join(", ", resetResult.Errors.Select(e => e.Description))}");
                        }
                    }

                    // Always ensure the account is unlocked on startup just in case
                    if (await userManager.IsLockedOutAsync(existingUser))
                    {
                        Console.WriteLine($"Unlocking account for {verifierData.Email}...");
                        await userManager.SetLockoutEndDateAsync(existingUser, null);
                        await userManager.ResetAccessFailedCountAsync(existingUser);
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