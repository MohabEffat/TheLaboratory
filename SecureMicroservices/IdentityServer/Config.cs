using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> GetApiScopes =>
        [
            new ApiScope("MovieAPI", "Movies")
        ];
        public static IEnumerable<Client> GetClients =>
        [
            new Client
            {
                ClientId = "movieClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("Secret".Sha256()) },
                AllowedScopes = { "MovieAPI" }
            }
        ];
        public static IEnumerable<IdentityResource> GetIdentityResources =>
        [

        ];
        public static IEnumerable<ApiResource> GetApiResources =>
        [

        ];
        public static List<TestUser> GetTestUsers =>
        [

        ];
    }
}
