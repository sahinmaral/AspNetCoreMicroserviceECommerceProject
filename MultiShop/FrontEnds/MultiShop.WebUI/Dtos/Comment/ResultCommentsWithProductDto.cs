using MultiShop.WebUI.Dtos.Product;

namespace MultiShop.WebUI.Dtos.Comment
{
    public class ResultCommentsWithProductDto
    {
        public ResultProductDto Product { get; set; }
        public List<ResultUserCommentDto> Comments { get; set; }
    }
}
