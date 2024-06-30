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
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IMapper _mapper;
        public CargoDetailsController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoDetailService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _cargoDetailService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _cargoDetailService.GetByIdAsync(id);
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoDetailDto dto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(dto);
            await _cargoDetailService.CreateAsync(cargoDetail);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCargoDetailDto dto)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(dto);
            await _cargoDetailService.UpdateAsync(cargoDetail);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cargoDetailService.DeleteAsync(id);
            return Ok();
        }
    }
}
