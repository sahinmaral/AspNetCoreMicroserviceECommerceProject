using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSlidersController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [HttpGet]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var featureSliders = await _featureSliderService.GetAllAsync();
            return Ok(featureSliders);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var featureSlider = await _featureSliderService.GetByIdAsync(id);
            return Ok(featureSlider);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateFeatureSliderDto dto)
        {
            await _featureSliderService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return Ok();
        }
    }
}
