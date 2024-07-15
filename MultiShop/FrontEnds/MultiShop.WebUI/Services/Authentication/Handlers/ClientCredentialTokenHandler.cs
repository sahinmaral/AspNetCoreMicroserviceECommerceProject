
using MultiShop.WebUI.Services.Authentication.Services.Abstract;

using System.Net;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Services.Authentication.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _clientCredentialTokenService.GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await base.SendAsync(request, cancellationToken);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();

            return response;
        }
    }
}
