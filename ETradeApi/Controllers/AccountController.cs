using AutoMapper;
using Business.Interfaces;
using Core.Utilities.Security;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ETradeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountService accountService, IMapper mapper, IConfiguration configuration)
        {
            _accountService = accountService;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost("Merchant/Applyment")]
        [ProducesResponseType(400, Type = typeof(List<string>))]
        public IActionResult Applyment([FromBody] AccountDto accountModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Account>(accountModel);
                model.Type = AccountType.Merchant;
                model.IsApplyment = true;
                var response = _accountService.AccountSignUp(model);
                return Ok(response.Result);
            }
            List<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
            return BadRequest(ModelState);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDto registerModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Account>(registerModel);
                model.Type = AccountType.Member;
                var response = _accountService.Register(model);
                return Ok(response.Result);
            }
            List<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto registerModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Login>(registerModel);
                var response = _accountService.Login(model).Result;
                if (response.Data != null)
                {
                    if (response.Data.IsApplyment)
                    {
                        return BadRequest("Üyeliğiniz henüz onaylanmamış");
                    }
                    else
                    {
                        string key = _configuration["JwtOptions:Key"];
                        List<Claim> claims = new List<Claim> {
                                    new Claim("id",response.Data.Id.ToString()),
                                    new Claim("type",((int)response.Data.Type).ToString()),
                                    new Claim(ClaimTypes.Name,response.Data.UserName),
                                    new Claim(ClaimTypes.Role,response.Data.Type.ToString()),
                                    };
                        string token = TokenService.GenerateToken(key, DateTime.Now.AddDays(30), claims);
                        return Ok(new { Token = token });
                    }
                }
                else
                {
                    return BadRequest("Kullanıcı adı yada şifre yanlış");
                }
                return Ok(response);
            }
            List<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
            return BadRequest(ModelState);
        }
    }
}
