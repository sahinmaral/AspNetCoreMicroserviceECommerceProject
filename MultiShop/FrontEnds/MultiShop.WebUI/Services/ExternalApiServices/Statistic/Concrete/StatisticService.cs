using MultiShop.WebUI.Dtos.Product;
using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Comment.Services.Concrete;
using MultiShop.WebUI.Services.ExternalApiServices.Discount.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Statistic.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Statistic.Concrete
{
    public class StatisticService : IStatisticService
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICommentService _commentService;
        private readonly IDiscountService _discountService;

        public StatisticService(ICategoryService categoryService, IProductService productService, IBrandService brandService, IUserService userService, ICommentService commentService, IDiscountService discountService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _brandService = brandService;
            _userService = userService;
            _commentService = commentService;
            _discountService = discountService;
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _brandService.CountAsync();
        }

        public async Task<int> GetCategoryCountAsync()
        {
            return await _categoryService.CountAsync();
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            return await _productService.AveragePriceAsync();
        }

        public async Task<int> GetProductCountAsync()
        {
            return await _productService.CountAsync();
        }

        public async Task<ResultProductDto> GetMostExpensiveProductAsync()
        {
            return await _productService.MostExpensiveProduct();
        }

        public async Task<ResultProductDto> GetMostCheapProductAsync()
        {
            return await _productService.MostCheapProduct();
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _userService.CountAsync();
        }

        public async Task<int> GetCommentCountByStatusAsync(bool status)
        {
            return await _commentService.CountByStatus(status);
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            return await _commentService.CountTotal();
        }

        public async Task<int> GetDiscountCountAsync()
        {
            return await _discountService.Count();
        }
    }
}
