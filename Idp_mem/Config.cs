// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Idp_mem
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource
                {
                    Name="api1",
                    DisplayName="my first idp_api",
                    Scopes =
                    {
                        "scope1"
                    }
                }
            };
      

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "scope1"}
                },

                new Client
                {
                    ClientId="apiClient",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    ClientName="api client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes =
                    {
                        "scope1"
                    }
                },

                //wpf client
                 new Client
                {
                    ClientId="wpf client",
                    ClientSecrets =
                    {
                        new Secret("wpf client".Sha256())
                    },
                    ClientName="wpf client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Email
                    }
                },

                  //mvc client,authorization code
                 new Client
                {
                    ClientId="mvc client",
                    ClientName="ASP .NET CORE MVC Client",
                    ClientSecrets =
                    {
                        new Secret("mvc client".Sha256())
                    },
                    
                    AllowedGrantTypes=GrantTypes.CodeAndClientCredentials,
                     RedirectUris =
                     {
                         "https://localhost:5005/signin-oidc"
                     },
                     FrontChannelLogoutUri="https://localshot:5005/siginout-oidc",
                     PostLogoutRedirectUris={
                        "https://localhost:5005/signout-callback-oidc"
                     },
                     AllowOfflineAccess=true, //allow offline_access
                     AlwaysIncludeUserClaimsInIdToken=true,//return all user info
                     AccessTokenLifetime=60, //60 seconds

                    AllowedScopes =
                    {
                        "scope1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Address
                    }
                },


                 //angular,implicit flow
                 new Client{
                     ClientId="angular-client",
                     ClientName="Angular SPA ¿Í»§¶Ë",
                     ClientUri="http://localhost:4200",

                     AllowedGrantTypes=GrantTypes.Implicit,
                     AllowAccessTokensViaBrowser=true,
                     RequireConsent=true,
                     AccessTokenLifetime=60*5,

                     RedirectUris={
                        "http://localhost:4200/signin-oidc",
                        "http://localhost:4200/redirect-silentrenew"
                     },

                     PostLogoutRedirectUris =
                     {
                         "http://localhost:4200"
                     },
                     AllowedCorsOrigins =
                     {
                         "http://localhost:4200"
                     },
                     AllowedScopes=
                     {
                         "scope1",
                         IdentityServerConstants.StandardScopes.OpenId,
                         IdentityServerConstants.StandardScopes.Profile,
                         IdentityServerConstants.StandardScopes.Email,
                         IdentityServerConstants.StandardScopes.Phone,
                         IdentityServerConstants.StandardScopes.Address
                     }
                 },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "scope2" }
                },
            };
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      