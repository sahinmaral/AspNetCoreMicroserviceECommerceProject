using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Dtos.Statistics;
using MultiShop.WebUI.Services.ExternalApiServices.Statistic.Abstract;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        public async Task<IActionResult> Index()
        {
            var statisticResult = new StatisticResultDto
            {
                CategoryCount = await _statisticService.GetCategoryCountAsync(),
                ProductCount = await _statisticService.GetProductCountAsync(),
                BrandCount = await _statisticService.GetBrandCountAsync(),
                UserCount = await _statisticService.GetUserCountAsync(),
                DiscountCount = await _statisticService.GetDiscountCountAsync(),
                ApprovedCommentCount = await _statisticService.GetCommentCountByStatusAsync(true),
                NotApprovedCommentCount = await _statisticService.GetCommentCountByStatusAsync(false),
                TotalCommentCount = await _statisticService.GetTotalCommentCountAsync(),
                ProductAvgPrice = await _statisticService.GetProductAvgPriceAsync(),
                MostExpensiveProduct = await _statisticService.GetMostExpensiveProductAsync(),
                MostCheapProduct = await _statisticService.GetMostCheapProductAsync()
            };

            return View(statisticResult);
        }
    }
}
