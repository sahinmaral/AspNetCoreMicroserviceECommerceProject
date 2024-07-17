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
            var cargoCustomers = await _cargoCustomerService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultCargoCustomerDto>>(cargoCustomers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var cargoCustomer = await _cargoCustomerService.GetByIdAsync(id);
            return Ok(_mapper.Map<ResultCargoCustomerDto>(cargoCustomer));
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var cargoCustomer = await _cargoCustomerService.GetByUserId(userId);
            return Ok(_mapper.Map<ResultCargoCustomerDto>(cargoCustomer));
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
