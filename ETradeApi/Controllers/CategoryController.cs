﻿using AutoMapper;
using Business.Interfaces;
using Core.Constant;
using Core.Entities.Interfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using ETradeApi.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ETradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize(Roles ="Admin")]
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
