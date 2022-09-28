using ECommerce.Infrastructure.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ECommerce.Infrastructure.Seeds
{
    public class AdminDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminDataSeed(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            var adminUser = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            IdentityResult result = null;
            var password = "Admin@gmail1234";

            if (await _userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                result = await _userManager.CreateAsync(adminUser, password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                    await _userManager.AddClaimAsync(adminUser, new Claim("Admin", "true"));
                }
            }
        }
    }
}
