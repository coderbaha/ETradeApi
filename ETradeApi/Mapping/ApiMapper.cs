using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.AuthDTOs;
using Entities.DTOs.CategoryDTOs;
using Entities.DTOs.ProductDTOs;
using ETradeApi.Model;

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
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product,ProductModel>().ReverseMap();
            //.ForMember(dest=>dest.Account.CompanyName,source => source.MapFrom(src=>src.AccountCompanyName))
            //.ForMember(dest => dest.Category.Name, source => source.MapFrom(src => src.CategoryName)).ReverseMap();
        }
    }
}
