using MultiShop.WebUI.Dtos.Product;

namespace MultiShop.WebUI.Dtos.Statistics
{
    public class StatisticResultDto
    {
        public int CategoryCount { get; set; }
        public int ProductCount { get; set; }
        public int BrandCount { get; set; }
        public int UserCount { get; set; }
        public int DiscountCount { get; set; }
        public int ApprovedCommentCount { get; set; }
        public int TotalCommentCount { get; set; }
        public decimal ProductAvgPrice { get; set; }
        public ResultProductDto MostExpensiveProduct { get; set; }
        public ResultProductDto MostCheapProduct { get; set; }
        public int NotApprovedCommentCount { get; set; }
    }
}
