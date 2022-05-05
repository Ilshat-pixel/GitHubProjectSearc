using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IdentityServer
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients(IConfiguration configuration) =>
       new List<Client>
       {
             new Client
            {
                ClientId = "client_id_search_service",
                ClientSecrets = { new Secret("client_secret_search_service".ToSha256()) },
                AllowedGrantTypes =  GrantTypes.ResourceOwnerPassword,
                AllowedCorsOrigins = {"https://localhost:44305"},
                AllowedScopes =
                {
                    "SearchAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                }
            },
            new Client
            {
                ClientId = "js",
                ClientName = "js Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequireClientSecret = false,
                AllowedScopes = {  "SearchAPI",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AllowOfflineAccess = true
            }
       };
        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("SearchAPI");
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        /// <summary>
        /// IdentityServer4 version 4.x.x changes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("SearchAPI", "Search API");
        }
    }
}
