using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Services.Concrete;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productDetailService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            return Ok(productDetail);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(string productId)
        {
            var productDetail = await _productDetailService.GetByProductIdAsync(productId);
            return Ok(productDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDetailDto dto)
        {
            await _productDetailService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteAsync(id);
            return Ok();
        }
    }
}
