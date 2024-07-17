using MultiShop.WebUI.Dtos.Message;
using MultiShop.WebUI.Services.ExternalApiServices.Message.Abstract;

namespace MultiShop.WebUI.Services.ExternalApiServices.Message.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageApi _messageApi;

        public MessageService(IMessageApi messageApi)
        {
            _messageApi = messageApi;
        }

        public async Task<int> CountAsync()
        {
            return await _messageApi.Count();
        }

        public async Task CreateAsync(CreateUserMessageDto dto)
        {
            await _messageApi.CreateMessage(dto);
        }

        public async Task<List<ResultUserMessageDto>> GetAllAsync()
        {
            return await _messageApi.GetMessages();
        }

        public async Task<List<ResultInboxMessageDto>> GetAllByReceiverIdAsync(string receiverId)
        {
            return await _messageApi.GetMessagesByReceiverId(receiverId);
        }

        public async Task<List<ResultSendboxMessageDto>> GetAllBySenderIdAsync(string senderId)
        {
            return await _messageApi.GetMessagesBySenderId(senderId);
        }

        public async Task<ResultUserMessageDto> GetByIdAsync(string id)
        {
            return await _messageApi.GetMessageById(id);
        }
    }
}
