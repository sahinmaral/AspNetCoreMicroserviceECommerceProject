using AutoMapper;

using MultiShop.Comment.Dtos;
using MultiShop.Comment.Entities.Concrete;

namespace MultiShop.Comment.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommentDto, UserComment>().ReverseMap();
            CreateMap<ResultUserCommentDto, UserComment>().ReverseMap();
        }
    }
}
