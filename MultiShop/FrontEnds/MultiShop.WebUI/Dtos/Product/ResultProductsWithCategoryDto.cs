using MultiShop.WebUI.Dtos.Category;

namespace MultiShop.WebUI.Dtos.Product
{
    public class ResultProductsWithCategoryDto
    {
        public List<ResultProductDto> Products { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
