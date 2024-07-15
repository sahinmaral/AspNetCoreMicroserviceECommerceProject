using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Comment;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Comment.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentApi _commentApi;
        private readonly ICatalogApi _catalogApi;

        public CommentController(ICommentApi commentApi, ICatalogApi catalogApi)
        {
            _commentApi = commentApi;
            _catalogApi = catalogApi;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var comments = await _commentApi.GetComments();

                var productByCommentFetchTask = comments.Select((comment) =>
                {
                    return _catalogApi.GetProductById(comment.ProductId);
                }).ToArray();

                var productByCommentFetchTaskResponse = await Task.WhenAll(productByCommentFetchTask);

                var commentsWithProduct = comments.Select((comment) =>
                {
                    var productOfComment = productByCommentFetchTaskResponse.First(x => x.Id == comment.ProductId);
                    return new ResultCommentDetailedDto()
                    {
                        Id = comment.Id,
                        UserImageUrl = comment.UserImageUrl,
                        UserNameSurname = comment.UserNameSurname,
                        UserEmail = comment.UserEmail,
                        Content = comment.Content,
                        Rating = comment.Rating, 
                        Status = comment.Status,
                        CreatedAt = comment.CreatedAt,
                        Product = productOfComment,
                    };
                }).ToList();

                return View(commentsWithProduct);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Yorumları getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [Route("admin/comment/verify/{commentId}")]
        public async Task<IActionResult> VerifyCommentAsync(string commentId)
        {
            try
            {
                var comment = await _commentApi.GetCommentById(commentId);
                var product = await _catalogApi.GetProductById(comment.ProductId);
                return View(new ResultCommentDetailedDto()
                {
                    Id = comment.Id,
                    UserImageUrl = comment.UserImageUrl,
                    UserNameSurname = comment.UserNameSurname,
                    UserEmail = comment.UserEmail,
                    Content = comment.Content,
                    Rating = comment.Rating,
                    Status = comment.Status,
                    CreatedAt = comment.CreatedAt,
                    Product = product,
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Yorumu getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateComment(ResultCommentDetailedDto dto)
        {     
            try
            {
                var comment = await _commentApi.GetCommentById(dto.Id);
                comment.Content = dto.Content;
                comment.Status = dto.Status;

                await _commentApi.UpdateComment(new ResultUserCommentDto
                {
                    Id = comment.Id,
                    UserImageUrl = comment.UserImageUrl,
                    UserNameSurname = comment.UserNameSurname,
                    UserEmail = comment.UserEmail,
                    Content = comment.Content,
                    Rating = comment.Rating,
                    Status = comment.Status,
                    CreatedAt = comment.CreatedAt,
                    ProductId = comment.ProductId
                });

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Yorumu güncellerken hata oluştu: {ex.Message}");
                return RedirectToAction("VerifyComment", new { commentId = dto.Id});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _commentApi.DeleteComment(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Yorumu silerken hata oluştu: {ex.Message}");
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
