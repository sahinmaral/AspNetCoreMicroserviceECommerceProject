using MultiShop.WebUI.Dtos.Comment;
using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Comment.Abstract
{
    public interface ICommentApi
    {
        [Get("/comments/countByStatus")]
        Task<int> GetCommentCountByStatus([Query] bool status);
        [Get("/comments/countTotal")]
        Task<int> GetTotalCountOfComment();
        [Post("/comments")]
        Task CreateComment(CreateUserCommentDto dto);
        [Get("/comments/product/{productId}")]
        Task<List<ResultUserCommentDto>> GetCommentsByProductId(string productId, [Query] bool status = true);
        [Get("/comments")]
        Task<List<ResultUserCommentDto>> GetComments([Query] bool status = true);
        [Get("/comments/{id}")]
        Task<ResultUserCommentDto> GetCommentById(string id);
        [Delete("/comments/{id}")]
        Task DeleteComment(string id);
        [Put("/comments")]
        Task UpdateComment(ResultUserCommentDto resultUserCommentDto);
    }
}
