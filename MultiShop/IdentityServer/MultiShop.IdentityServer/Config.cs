using IdentityServer4;
using IdentityServer4.Models;

using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource
            {
                Name = "ResourceCatalog",
                Scopes =
                {
                    "CatalogFullPermission",
                    "CatalogReadPermission"
                }
            },
            new ApiResource
            {
                Name = "ResourceDiscount",
                Scopes =
                {
                    "DiscountFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceOrder",
                Scopes =
                {
                    "OrderFullPermission",
                }
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope
            {
                Name = "CatalogFullPermission",
                DisplayName = "Full authority for catalog operations"
            },
            new ApiScope
            {
                Name = "CatalogReadPermission",
                DisplayName = "Reading authority for catalog operations"
            },
            new ApiScope
            {
                Name = "DiscountFullPermission",
                DisplayName = "Full authority for discount operations"
            },
            new ApiScope
            {
                Name = "OrderFullPermission",
                DisplayName = "Full authority for order operations"
            },
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission" }
            },

            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = {"CatalogReadPermission", "CatalogFullPermission" }
            },

            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "DiscountFullPermission", "CatalogReadPermission", "CatalogFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,               
                },
                AccessTokenLifetime = 600
            }
        };
    }
}