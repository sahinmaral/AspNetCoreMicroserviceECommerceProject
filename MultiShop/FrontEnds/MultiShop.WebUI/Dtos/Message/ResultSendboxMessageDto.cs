using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Dtos.Message
{
    public class ResultSendboxMessageDto
    {
        public string Id { get; set; }
        public string ReceiverId { get; set; }
        public UserDetailViewModel Receiver { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
