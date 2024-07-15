using MultiShop.WebUI.Dtos.Comment;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract
{
    public interface ICommentService
    {
        Task<List<ResultUserCommentDto>> GetAllAsync();
        Task CreateAsync(CreateUserCommentDto dto);
        Task UpdateAsync(ResultUserCommentDto dto);
        Task DeleteAsync(string id);
        Task<ResultUserCommentDto> GetByIdAsync(string id);
        Task<List<ResultUserCommentDto>> GetAllByProductId(string productId, [Query] bool status = true);
    }
}
