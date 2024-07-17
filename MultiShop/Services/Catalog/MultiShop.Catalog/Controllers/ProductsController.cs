using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
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
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("category/{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAllByCategoryId(string id)
        {
            var products = await _productService.GetAllByCategoryIdAsync(id);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost("images")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> AddProductImages(ResultProductImagesDto dto)
        {
            await _productService.AddProductImages(dto);
            return Ok();
        }

        [HttpPut("images")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> UpdateProductImages(ResultProductImagesDto dto)
        {
            await _productService.UpdateProductImages(dto);
            return Ok();
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            await _productService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            await _productService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("count")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> Count()
        {
            var count = await _productService.CountAsync();
            return Ok(count);
        }

        [HttpGet("averagePrice")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> AveragePrice()
        {
            var averagePrice = await _productService.AveragePriceAsync();
            return Ok(averagePrice);
        }

        [HttpGet("mostExpensive")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> MostExpensiveProduct()
        {
            var product = await _productService.MostExpensiveProduct();
            return Ok(product);
        }

        [HttpGet("mostCheap")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> MostCheapProduct()
        {
            var product = await _productService.MostCheapProduct();
            return Ok(product);
        }
    }
}
