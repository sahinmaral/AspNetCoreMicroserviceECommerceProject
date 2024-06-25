using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productImageService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var productImage = await _productImageService.GetByIdAsync(id);
            return Ok(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductImageDto dto)
        {
            await _productImageService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductImageDto dto)
        {
            await _productImageService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productImageService.DeleteAsync(id);
            return Ok();
        }
    }
}
