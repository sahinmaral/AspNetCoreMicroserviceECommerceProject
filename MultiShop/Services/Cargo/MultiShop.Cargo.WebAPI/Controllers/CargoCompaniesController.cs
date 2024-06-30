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
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;
        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _cargoCompanyService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await _cargoCompanyService.GetByIdAsync(id);
            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCargoCompanyDto dto)
        {
            var cargoCompany = _mapper.Map<CargoCompany>(dto);
            await _cargoCompanyService.CreateAsync(cargoCompany);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCargoCompanyDto dto)
        {
            var cargoCompany = _mapper.Map<CargoCompany>(dto);
            await _cargoCompanyService.UpdateAsync(cargoCompany);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _cargoCompanyService.DeleteAsync(id);
            return Ok();
        }
    }
}
