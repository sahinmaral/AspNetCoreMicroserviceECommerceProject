using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
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
        public async Task<IActionResult> GetAll()
        {
            var featureSliders = await _featureSliderService.GetAllAsync();
            return Ok(featureSliders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var featureSlider = await _featureSliderService.GetByIdAsync(id);
            return Ok(featureSlider);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDto dto)
        {
            await _featureSliderService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return Ok();
        }
    }
}
