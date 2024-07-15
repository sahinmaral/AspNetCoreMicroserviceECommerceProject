using Humanizer;

using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;

using Microsoft.Extensions.Options;

using MultiShop.WebUI.Services.Authentication.Models;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.Ocelot.Models;

namespace MultiShop.WebUI.Services.Authentication.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly ClientSettings _clientSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IClientAccessTokenCache _clientAccessTokenCache;

        public ClientCredentialTokenService(
            IOptions<ServiceApiSettings> serviceApiSettingsOptions,
            IOptions<ClientSettings> clientSettingsOptions,
            IHttpClientFactory httpClientFactory, 
            IClientAccessTokenCache clientAccessTokenCache)
        {
            _httpClientFactory = httpClientFactory;
            _clientAccessTokenCache = clientAccessTokenCache;
            _serviceApiSettings = serviceApiSettingsOptions.Value;
            _clientSettings = clientSettingsOptions.Value;
        }

        public async Task<string> GetToken()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var currentToken = await _clientAccessTokenCache.GetAsync("multishoptoken", new ClientAccessTokenParameters());
            if(currentToken is not null)
            {
                return currentToken.AccessToken;
            }

            var discoveryEndpoint = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityApiUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret,
                Address = discoveryEndpoint.TokenEndpoint
            };

            var newToken = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await _clientAccessTokenCache.SetAsync("multishoptoken", newToken.AccessToken, newToken.ExpiresIn, new ClientAccessTokenParameters());
            return newToken.AccessToken;
        }
    }
}
