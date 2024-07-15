using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.CustomerService;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServicesController : ControllerBase
    {
        private readonly ICustomerServiceService _customerServiceService;

        public CustomerServicesController(ICustomerServiceService customerServiceService)
        {
            _customerServiceService = customerServiceService;
        }

        [HttpGet]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetAll()
        {
            var customerServices = await _customerServiceService.GetAllAsync();
            return Ok(customerServices);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var customerService = await _customerServiceService.GetByIdAsync(id);
            return Ok(customerService);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Create(CreateCustomerServiceDto dto)
        {
            await _customerServiceService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateCustomerServiceDto dto)
        {
            await _customerServiceService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _customerServiceService.DeleteAsync(id);
            return Ok();
        }
    }
}
