using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Enums.Identity;
using Nabd.Infrastructure.Data;
using System.Security.Claims;

namespace Nabd.API.Controllers
{
    [ApiController]
    [Route("api/debug")]
    public class DebugController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly NabdDbContext _context;

        public DebugController(UserManager<User> userManager, RoleManager<Role> roleManager, NabdDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet("fix-verifier")]
        public async Task<IActionResult> FixVerifier()
        {
            var email = "zakaria@nabd.com";
            var password = "Zak123#";

            // 1. Find existing
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                // Delete to start fresh
                await _userManager.DeleteAsync(user);
            }

            // 2. Create Role if missing
            if (!await _roleManager.RoleExistsAsync("Verifier"))
            {
                await _roleManager.CreateAsync(new Role { Name = "Verifier" });
            }

            // 3. Create User
            var newUser = new Verifier
            {
                FirstName = "زكريا",
                LastName = "نبض",
                Email = email,
                UserName = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                CreatedAt = DateTime.UtcNow,
                LockoutEnabled = false // Important!
            };

            var result = await _userManager.CreateAsync(newUser, password);

            if (!result.Succeeded)
            {
                return BadRequest(new { error = "Create failed", details = result.Errors });
            }

            // 4. Assign Role
            var roleResult = await _userManager.AddToRoleAsync(newUser, "Verifier");

            // 5. Ensure Claims (optional but good)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, newUser.Id.ToString()),
                new Claim(ClaimTypes.Email, newUser.Email),
                new Claim(ClaimTypes.Role, "Verifier")
            };
            await _userManager.AddClaimsAsync(newUser, claims);

            return Ok(new 
            { 
                message = "Verifier recreated successfully", 
                email = email, 
                password = password,
                roleStatus = roleResult.Succeeded ? "Assigned" : "Failed"
            });
        }
    }
}
