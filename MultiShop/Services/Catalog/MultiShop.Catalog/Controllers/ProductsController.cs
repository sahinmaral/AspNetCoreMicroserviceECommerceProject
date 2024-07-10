using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetAllByCategoryId(string id)
        {
            var categories = await _productService.GetAllByCategoryIdAsync(id);
            return Ok(categories);
        }

        [HttpPost("images")]
        public async Task<IActionResult> AddProductImages(ResultProductImagesDto dto)
        {
            await _productService.AddProductImages(dto);
            return Ok();
        }

        [HttpPut("images")]
        public async Task<IActionResult> UpdateProductImages(ResultProductImagesDto dto)
        {
            await _productService.UpdateProductImages(dto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            await _productService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            await _productService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }
    }
}
