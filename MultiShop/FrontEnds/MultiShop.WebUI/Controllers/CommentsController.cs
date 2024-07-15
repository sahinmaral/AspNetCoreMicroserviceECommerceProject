using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Comment;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.Controllers
{

    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommentDto dto)
        {
            string productId = dto.ProductId;

            try
            {
                await _commentService.CreateAsync(dto);
                return RedirectToAction("Detail", "Products", new { id = productId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Yorumu kaydederken hata oluştu: {ex.Message}");
                return RedirectToAction("Detail", "Products", new { id = productId });
            }
        }
    }
}
