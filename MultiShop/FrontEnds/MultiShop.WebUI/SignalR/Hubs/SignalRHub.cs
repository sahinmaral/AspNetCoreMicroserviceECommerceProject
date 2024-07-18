using Microsoft.AspNetCore.SignalR;

using MultiShop.WebUI.Services.ExternalApiServices.Catalog.Services.Abstract;

namespace MultiShop.WebUI.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICommentService _commentService;

        public SignalRHub(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task SendTotalCommentCount()
        {
            var totalCommentCount = await _commentService.CountTotal();
            await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);
        }
    }
}
