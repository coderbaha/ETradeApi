using AutoMapper;
using Business.Interfaces;
using Entities.Concrete;
using Entities.DTOs.ProductDTOs;
using ETradeApi.Controllers.BaseController;
using ETradeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq.Expressions;

namespace ETradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController<Product, ProductAddDto, ProductUpdateDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public ProductController(IProductService productService, IMapper mapper, IConfiguration configuration)
            : base(productService, mapper)
        {
            _productService = productService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("AddAsync")]
        public override IActionResult AddAsync([FromBody] ProductAddDto addModel)
        {
            var model = _mapper.Map<Product>(addModel);
            //int accountId = int.Parse(HttpContext.User.FindFirst("id").Value);
            model.AccountId = 7;
            var response = _mapper.Map<ProductModel>(_productService.AddAsync(model).Result.Data);
            return Ok(response);
        }
        [HttpPut("UpdateAsync")]
        public override IActionResult UpdateAsync([FromBody] ProductUpdateDto updateModel)
        {
            var model = _mapper.Map<Product>(updateModel);
            //int accountId = int.Parse(HttpContext.User.FindFirst("id").Value);
            model.AccountId = 7;
            var response = _mapper.Map<ProductModel>(_productService.UpdateAsync(model).Result.Data);
            return Ok(response);
        }
        [HttpGet("GetByAccountIdListAsync")]
        public IActionResult GetByAccountIdList(int accountId)
        {
            Expression<Func<Product, bool>> filter(int accountId)
            {
                return x => x.AccountId == accountId;
            }
            var list = _productService.GetAllAsync(false, filter(accountId)).Result;
            if (list.Data.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpPut("UpdateAccountByIdAsync")]
        public IActionResult UpdateAccountById([FromBody] ProductUpdateDto updateModel,int accountId)
        {
            var model = _mapper.Map<Product>(updateModel);
            //int accountId = int.Parse(HttpContext.User.FindFirst("id").Value);
            model.AccountId = 7;
            var response = _productService.UpdateAccountByIdAsync(model,accountId,"Admin").Result;
            return Ok(response);
        }
    }
}
