using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Services.Abstract;

namespace MultiShop.Catalog.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> GetById(string id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            return Ok(contact);
        }

        [HttpPost]
        [Authorize(Policy = "CatalogReadPermission")]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            await _contactService.CreateAsync(dto);
            return Ok();
        }

        [HttpPut]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            await _contactService.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "CatalogFullPermission")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactService.DeleteAsync(id);
            return Ok();
        }
    }
}
