using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.CustomerService;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServicesController : ControllerBase
    {
        private readonly ICustomerServiceService _customerServıceService;

        public CustomerServicesController(ICustomerServiceService customerServıceService)
        {
            _customerServıceService = customerServıceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _customerServıceService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var customerServıce = await _customerServıceService.GetByIdAsync(id);
            return Ok(customerServıce);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerServiceDto dto)
        {
            await _customerServıceService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerServiceDto dto)
        {
            await _customerServıceService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerServıceService.DeleteAsync(id);
            return Ok();
        }
    }
}
