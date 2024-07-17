using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MultiShop.Message.Context;
using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;
using MultiShop.Message.Services.Abstract;

namespace MultiShop.Message.Services.Concrete
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task<int> CountAsync()
        {
            var count = await _messageContext.UserMessages.CountAsync();
            return count;
        }

        public async Task CreateAsync(CreateUserMessageDto dto)
        {
            var userMessage = _mapper.Map<UserMessage>(dto);
            _messageContext.Entry(userMessage).State = EntityState.Added;
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultUserMessageDto>> GetAllAsync()
        {
            var messages = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultUserMessageDto>>(messages);
        }

        public async Task<List<ResultInboxMessageDto>> GetAllByReceiverId(string receiverId)
        {
            var messages = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(messages);
        }

        public async Task<List<ResultSendboxMessageDto>> GetAllBySenderId(string senderId)
        {
            var messages = await _messageContext.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(messages);
        }

        public async Task<GetByUserMessageIdDto?> GetByIdAsync(string id)
        {
            var message = await _messageContext.UserMessages.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<GetByUserMessageIdDto>(message);
        }
    }
}
