using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
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
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var productDetails = await _productDetailService.GetAllAsync();
            return Ok(productDetails);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var productDetail = await _productDetailService.GetByIdAsync(id);
            return Ok(productDetail);
        }

        [HttpGet("product/{productId}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetByProductId(string productId)
        {
            var productDetail = await _productDetailService.GetByProductIdAsync(productId);
            return Ok(productDetail);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateProductDetailDto dto)
        {
            await _productDetailService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateProductDetailDto dto)
        {
            await _productDetailService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productDetailService.DeleteAsync(id);
            return Ok();
        }
    }
}
