using Microsoft.AspNetCore.Mvc;

using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services.Abstract;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _discountService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto dto)
        {
            await _discountService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto dto)
        {
            await _discountService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _discountService.DeleteAsync(id);
            return Ok();
        }
    }
}
