using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Authentication.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel?> GetUserInfo();
        Task<UserDetailViewModel?> GetById(string userId);
        Task<List<UserDetailViewModel>> GetAll();
        Task<int> CountAsync();
    }
}
