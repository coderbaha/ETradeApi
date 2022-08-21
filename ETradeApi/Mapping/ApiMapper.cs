using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AuthDTOs;
using Entities.DTOs.CategoryDTOs;

namespace ETradeApi.Mapping
{
    public class ApiMapper:Profile
    {
        public ApiMapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, RegisterDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        }
    }
}
