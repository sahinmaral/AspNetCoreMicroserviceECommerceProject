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
            new ApiResource
            {
                Name = "ResourceCargo",
                Scopes =
                {
                    "CargoFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceBasket",
                Scopes =
                {
                    "BasketFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceOcelot",
                Scopes =
                {
                    "OcelotFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceComment",
                Scopes =
                {
                    "CommentReadPermission",
                    "CommentFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourcePayment",
                Scopes =
                {
                    "PaymentFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceImageStorage",
                Scopes =
                {
                    "ImageStorageFullPermission",
                }
            },
            new ApiResource
            {
                Name = "ResourceMessage",
                Scopes =
                {
                    "MessageFullPermission",
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
            new ApiScope
            {
                Name = "CargoFullPermission",
                DisplayName = "Full authority for cargo operations"
            },
            new ApiScope
            {
                Name = "BasketFullPermission",
                DisplayName = "Full authority for basket operations"
            },
            new ApiScope
            {
                Name = "CommentFullPermission",
                DisplayName = "Full authority for comment operations"
            },
            new ApiScope
            {
                Name = "CommentReadPermission",
                DisplayName = "Read authority for comment operations"
            },
            new ApiScope
            {
                Name = "PaymentFullPermission",
                DisplayName = "Full authority for payment operations"
            },
            new ApiScope
            {
                Name = "ImageStorageFullPermission",
                DisplayName = "Full authority for image storage operations"
            },
            new ApiScope
            {
                Name = "MessageFullPermission",
                DisplayName = "Full authority for message operations"
            },
            new ApiScope
            {
                Name = "OcelotFullPermission",
                DisplayName = "Full authority for ocelot operations"
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
                AllowedScopes = { 
                    "DiscountFullPermission",
                    "CommentReadPermission", 
                    "ImageStorageFullPermission",
                    "CatalogReadPermission",
                    "OcelotFullPermission",
                }
            },

            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = {
                    "CatalogReadPermission", 
                    "CatalogFullPermission", 
                    "BasketFullPermission", 
                    "PaymentFullPermission", 
                    "CommentFullPermission",
                    "ImageStorageFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "MessageFullPermission",
                    "CargoFullPermission",
                    "OcelotFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                }
            },

            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = {
                    "DiscountFullPermission",
                    "CatalogReadPermission",
                    "CatalogFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "CommentFullPermission",
                    "ImageStorageFullPermission",
                    "PaymentFullPermission",
                    "OcelotFullPermission",
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