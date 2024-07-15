namespace MultiShop.WebUI.Services.Authentication.Services.Abstract
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetToken();
    }
}
