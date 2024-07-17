using MultiShop.WebUI.Dtos.Message;

using Refit;

namespace MultiShop.WebUI.Services.ExternalApiServices.Message.Abstract
{
    public interface IMessageApi
    {
        [Get("/messages")]
        Task<List<ResultUserMessageDto>> GetMessages();
        [Get("/messages/count")]
        Task<int> Count();
        [Get("/messages/receiver/{receiverId}")]
        Task<List<ResultInboxMessageDto>> GetMessagesByReceiverId(string receiverId);
        [Get("/messages/sender/{senderId}")]
        Task<List<ResultSendboxMessageDto>> GetMessagesBySenderId(string senderId);
        [Post("/messages")]
        Task CreateMessage(CreateUserMessageDto dto);
        [Get("/messages/{id}")]
        Task<ResultUserMessageDto> GetMessageById(string id);
    }
}
