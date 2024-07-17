using Microsoft.AspNetCore.Mvc;

using MultiShop.WebUI.Services.Authentication.Services.Abstract;
using MultiShop.WebUI.Services.ExternalApiServices.Message.Abstract;

namespace MultiShop.WebUI.ViewComponents
{
    public class UserLayoutNavbarMessageInboxViewComponent : ViewComponent
    {
        private readonly IIdentityService _identityService;
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public UserLayoutNavbarMessageInboxViewComponent(IIdentityService identityService, IMessageService messageService, IUserService userService)
        {
            _identityService = identityService;
            _messageService = messageService;
            _userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}
