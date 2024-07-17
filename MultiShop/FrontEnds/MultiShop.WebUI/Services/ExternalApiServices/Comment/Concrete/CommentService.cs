using MultiShop.WebUI.Dtos.Comment;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Comment.Abstract;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Comment.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentApi _catalogApiClientCredential;
        private readonly ICommentApi _catalogApiResourceOwnerPasswordCommentApi;

        public CommentService(IHttpClientFactory clientFactory)
        {
            _catalogApiClientCredential = RestService.For<ICommentApi>(clientFactory.CreateClient("ClientCredentialCommentApi"));
            _catalogApiResourceOwnerPasswordCommentApi = RestService.For<ICommentApi>(clientFactory.CreateClient("ResourceOwnerPasswordCommentApi"));
        }


        public async Task CreateAsync(CreateUserCommentDto dto)
        {
            await _catalogApiResourceOwnerPasswordCommentApi.CreateComment(dto);
        }
        public async Task DeleteAsync(string id)
        {
            await _catalogApiResourceOwnerPasswordCommentApi.DeleteComment(id);
        }
        public async Task<ResultUserCommentDto> GetByIdAsync(string id)
        {
            return await _catalogApiClientCredential.GetCommentById(id);
        }
        public async Task<List<ResultUserCommentDto>> GetAllAsync()
        {
            return await _catalogApiClientCredential.GetComments();
        }
        public async Task UpdateAsync(ResultUserCommentDto dto)
        {
            await _catalogApiResourceOwnerPasswordCommentApi.UpdateComment(dto);
        }

        public async Task<List<ResultUserCommentDto>> GetAllByProductId(string productId, bool status)
        {
            return await _catalogApiClientCredential.GetCommentsByProductId(productId, status);
        }

        public async Task<int> CountByStatus(bool status)
        {
            return await _catalogApiClientCredential.GetCommentCountByStatus(status);
        }

        public async Task<int> CountTotal()
        {
            return await _catalogApiClientCredential.GetTotalCountOfComment();
        }
    }
}
