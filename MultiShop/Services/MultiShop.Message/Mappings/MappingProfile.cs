using AutoMapper;

using MultiShop.Message.Dtos;
using MultiShop.Message.Entities;

namespace MultiShop.Message.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserMessage, CreateUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultUserMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultInboxMessageDto>().ReverseMap();
            CreateMap<UserMessage, ResultSendboxMessageDto>().ReverseMap();
        }
    }
}
