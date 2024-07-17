using MultiShop.WebUI.Dtos.Message;

namespace MultiShop.WebUI.Services.ExternalApiServices.Message.Abstract
{
    public interface IMessageService
    {
        Task<ResultUserMessageDto> GetByIdAsync(string id);
        Task<List<ResultUserMessageDto>> GetAllAsync();
        Task<List<ResultInboxMessageDto>> GetAllByReceiverIdAsync(string receiverId);
        Task<List<ResultSendboxMessageDto>> GetAllBySenderIdAsync(string senderId);
        Task CreateAsync(CreateUserMessageDto dto);
        Task<int> CountAsync();
    }
}
