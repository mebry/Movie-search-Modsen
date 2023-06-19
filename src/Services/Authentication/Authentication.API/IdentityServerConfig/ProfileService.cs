using Authentication.API.Constants;
using DataAccess.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Authentication.API.IdentityServerConfig
{
    public class ProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;

        public ProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.AddRange(context.Subject.Claims);

            var user = await _userManager.GetUserAsync(context.Subject);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(role => new Claim(IdentityServerConstants.ROLE_IDENTITY_RECOURCE_NAME, role));

            context.IssuedClaims.AddRange(roleClaims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = user != null ? true : false;
        }
    }
}
