using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Message.Dtos;
using MultiShop.Message.Services.Abstract;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public MessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userMessages = await _userMessageService.GetAllAsync();
            return Ok(userMessages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var userMessage = await _userMessageService.GetByIdAsync(id);
            return Ok(userMessage);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var count = await _userMessageService.CountAsync();
            return Ok(count);
        }

        [HttpGet("sender/{senderId}")]
        public async Task<IActionResult> GetAllBySenderId(string senderId)
        {
            var userMessages = await _userMessageService.GetAllBySenderId(senderId);
            return Ok(userMessages);
        }

        [HttpGet("receiver/{receiverId}")]
        public async Task<IActionResult> GetAllByReceiverId(string receiverId)
        {
            var userMessages = await _userMessageService.GetAllByReceiverId(receiverId);
            return Ok(userMessages);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserMessageDto dto)
        {
            await _userMessageService.CreateAsync(dto);
            return Ok();
        }
    }
}
