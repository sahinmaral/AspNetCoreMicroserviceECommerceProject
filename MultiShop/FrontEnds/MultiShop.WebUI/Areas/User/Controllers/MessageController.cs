using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Message.Abstract;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IIdentityService identityService, IMessageService messageService, IUserService userService)
        {
            _identityService = identityService;
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> InboxAsync()
        {
            var currentUserId = _identityService.CurrentUserId;
            var messages = await _messageService.GetAllByReceiverIdAsync(currentUserId);
            messages.ForEach((message) =>
            {
                var sender = _userService.GetById(message.SenderId).Result;
                message.Sender = sender;
            });
            return View(messages);
        }

        public async Task<IActionResult> SendboxAsync()
        {
            var currentUserId = _identityService.CurrentUserId;
            var messages = await _messageService.GetAllBySenderIdAsync(currentUserId);
            messages.ForEach((message) =>
            {
                var receiver = _userService.GetById(message.ReceiverId).Result;
                message.Receiver = receiver;
            });
            return View(messages);
        }
    }
}
