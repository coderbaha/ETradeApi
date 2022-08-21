using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;

namespace ETradeApi.Mapping
{
    public class ApiMapper:Profile
    {
        public ApiMapper()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Account, RegisterDto>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}
