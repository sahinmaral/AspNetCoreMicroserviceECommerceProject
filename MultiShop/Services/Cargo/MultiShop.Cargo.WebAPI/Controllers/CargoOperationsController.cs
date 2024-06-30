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
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;
        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _cargoOperationService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _cargoOperationService.GetByIdAsync(id);
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoOperationDto dto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(dto);
            await _cargoOperationService.CreateAsync(cargoOperation);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCargoOperationDto dto)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(dto);
            await _cargoOperationService.UpdateAsync(cargoOperation);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cargoOperationService.DeleteAsync(id);
            return Ok();
        }
    }
}
