using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;

namespace ngScaffolding_oauth
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            //var resource = new ApiResource("ngscaffolding", "ngscaffolding.Api");
            //resource.UserClaims = new List<string>{ "ngScaffoldingIdentity" };

            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "ngscaffoldingAPI",
                    DisplayName = "ngScaffolding.Api",
                    UserClaims = {JwtClaimTypes.Role}
                },
                new ApiResource
                {
                    Name = "demoAPI",
                    DisplayName = "demo.Api",
                    UserClaims = {JwtClaimTypes.Role}
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "ngscaffoldingAPI",
                    UserClaims = new List<string> {"userid", "name", JwtClaimTypes.Role, "email"}
                },
                new IdentityResource
                {
                    Name = "demoAPI",
                    UserClaims = new List<string> {"userid", "name", JwtClaimTypes.Role, "email"}
                },
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ngscaffolding_client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AccessTokenLifetime = 86400, // 24 Hours
                    RefreshTokenUsage = TokenUsage.ReUse,
                    UpdateAccessTokenClaimsOnRefresh = true,

                    AllowedScopes = { "ngscaffoldingAPI", "demoAPI", "openid" },

                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "siteadmin",
                    Username = "siteadmin",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Name, "Site Admin"),
                        new Claim(JwtClaimTypes.Email, "siteadmin@mail.com"),
                        new Claim(JwtClaimTypes.Role, "user"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
