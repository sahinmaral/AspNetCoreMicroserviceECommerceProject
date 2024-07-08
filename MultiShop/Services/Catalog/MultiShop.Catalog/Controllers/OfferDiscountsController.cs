using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _specialOfferService;

        public OfferDiscountsController(IOfferDiscountService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _specialOfferService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var specialOffer = await _specialOfferService.GetByIdAsync(id);
            return Ok(specialOffer);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDiscountDto dto)
        {
            await _specialOfferService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto dto)
        {
            await _specialOfferService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _specialOfferService.DeleteAsync(id);
            return Ok();
        }
    }
}
