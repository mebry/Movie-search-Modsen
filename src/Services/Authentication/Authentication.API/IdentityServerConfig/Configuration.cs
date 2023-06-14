using IdentityServer4.Models;
using Authentication.API.Constants;
using IdentityModel;

namespace Authentication.API.IdentityServerConfig
{
    public static class Configuration
    {
        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource>
            {
                new ApiResource(IdentityServerConstants.RATING_API_RESOURCE_NAME),
                new ApiResource(IdentityServer4.IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(IdentityServerConstants.ROLE_IDENTITY_RECOURCE_NAME, new List<string>() {IdentityServerConstants.ROLE_IDENTITY_RECOURCE_NAME})
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = IdentityServerConstants.CLIENT_ID,
                    ClientSecrets = { new Secret(IdentityServerConstants.CLIENT_SECRET.ToSha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {
                        IdentityServerConstants.RATING_API_RESOURCE_NAME,
                        IdentityServer4.IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.ROLE_IDENTITY_RECOURCE_NAME
                    }
                }
            };
    }
}
