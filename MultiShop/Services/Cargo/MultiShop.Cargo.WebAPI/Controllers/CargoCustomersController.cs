using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Concrete;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;
        public CargoCustomersController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _cargoCustomerService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _cargoCustomerService.GetByIdAsync(id);
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoCustomerDto dto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(dto);
            await _cargoCustomerService.CreateAsync(cargoCustomer);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCargoCustomerDto dto)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(dto);
            await _cargoCustomerService.UpdateAsync(cargoCustomer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cargoCustomerService.DeleteAsync(id);
            return Ok();
        }
    }
}
