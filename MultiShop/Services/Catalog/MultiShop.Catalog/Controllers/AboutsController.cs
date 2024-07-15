using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var abouts = await _aboutService.GetAllAsync();
            return Ok(abouts);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return Ok(about);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateAboutDto dto)
        {
            await _aboutService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateAboutDto dto)
        {
            await _aboutService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _aboutService.DeleteAsync(id);
            return Ok();
        }
    }
}
