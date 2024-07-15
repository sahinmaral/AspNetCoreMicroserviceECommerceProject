using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Comment;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Comment;

namespace MultiShop.WebUI.ViewComponents
{
    public class ProductDetailReviewViewComponent : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductDetailReviewViewComponent(IProductService productService, ICommentService commentService)
        {
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            try
            {
                var product = await _productService.GetByIdAsync(productId);
                var comments = await _commentService.GetAllByProductId(productId);

                return View(new ResultCommentsWithProductDto
                {
                    Comments = comments,
                    Product = product
                });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ürün yorumlarını getirirken hata oluştu: {ex.Message}");
                return View();
            }
        }
    }
}
