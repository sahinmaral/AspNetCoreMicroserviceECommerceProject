using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var specialOffers = await _specialOfferService.GetAllAsync();
            return Ok(specialOffers);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var specialOffer = await _specialOfferService.GetByIdAsync(id);
            return Ok(specialOffer);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateSpecialOfferDto dto)
        {
            await _specialOfferService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto dto)
        {
            await _specialOfferService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _specialOfferService.DeleteAsync(id);
            return Ok();
        }
    }
}
