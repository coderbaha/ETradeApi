using AutoMapper;
using Business.Interfaces;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using ETradeApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ETradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController<Category, CategoryAddDto, CategoryUpdateDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CategoryController(ICategoryService categoryService, IMapper mapper, IConfiguration configuration)
            : base(categoryService, mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _configuration = configuration;
        }
    }
}
