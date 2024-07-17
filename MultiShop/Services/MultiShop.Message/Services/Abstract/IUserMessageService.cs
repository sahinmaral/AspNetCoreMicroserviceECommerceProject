using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services.Abstract
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllAsync();
        Task<List<ResultSendboxMessageDto>> GetAllBySenderId(string senderId);
        Task<List<ResultInboxMessageDto>> GetAllByReceiverId(string receiverId);
        Task CreateAsync(CreateUserMessageDto dto);
        Task<GetByUserMessageIdDto?> GetByIdAsync(string id);
        Task<int> CountAsync();
    }
}
