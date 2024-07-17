using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;

namespace MultiShop.WebUI.Services.Authentication.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel?> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }

        public async Task<UserDetailViewModel?> GetById(string userId)
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>($"/api/users/detail/{userId}");
        }

        public async Task<List<UserDetailViewModel>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<UserDetailViewModel>>("/api/users/getusers");
        }

        public async Task<int> CountAsync()
        {
            return await _httpClient.GetFromJsonAsync<int>("/api/users/count");
        }
    }
}
