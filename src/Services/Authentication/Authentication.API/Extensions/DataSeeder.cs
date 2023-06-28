using DataAccess.Contexts;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using DataAccess.Seed;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Extensions
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<AuthContext>();
                using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                if (!context.Users.AsNoTracking().Any())
                {
                    var userToAdd = DataToSeed.GetAdminUserToAdd();
                    await userManager.CreateAsync(userToAdd, DataToSeed.AdminPassword);
                    await context.UserRoles.AddAsync(
                        new IdentityUserRole<string>
                        {
                            RoleId = "d877141c-3d7d-42b0-b35f-503b6bce5f0c",
                            UserId = userToAdd.Id
                        }
                        );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
