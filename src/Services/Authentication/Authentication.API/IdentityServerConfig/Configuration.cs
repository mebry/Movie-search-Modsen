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
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = IdentityServerConstants.CLIENT_ID,
                    ClientSecrets = { new Secret(IdentityServerConstants.CLIENT_SECRET.ToSha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {IdentityServerConstants.RATING_API_RESOURCE_NAME}
                }
            };
    }
}
