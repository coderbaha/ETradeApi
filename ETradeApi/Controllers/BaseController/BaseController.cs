using AutoMapper;
using Business.Interfaces;
using Core.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ETradeApi.Controllers.BaseController
{
    public abstract class BaseController<T, TMapAdd, TMapUpdate> : ControllerBase
        where T : class, IEntity, new()
        where TMapAdd : class, new()
        where TMapUpdate : class, new()
    {
        private readonly IBaseService<T> _baseService;
        private readonly IMapper _mapper;
        public BaseController(IBaseService<T> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }
        [HttpPost("AddAsync")]
        public virtual IActionResult AddAsync([FromBody] TMapAdd mapModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<T>(mapModel);
                var response = _baseService.AddAsync(model);
                return Ok(response.Result);
            }
            List<string> errors = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
            return BadRequest(ModelState);
        }
        [HttpGet("GetAllAsync")]
        public virtual IActionResult GetList()
        {
            var list = _baseService.GetAllAsync().Result;
            if (list.Data.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("GetByIdAsync")]
        public virtual IActionResult GetByIdAsync(int id)
        {
            var response = _baseService.GetByIdAsync(id).Result;
            if (response.Data == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        [HttpPut("UpdateAsync")]
        public virtual IActionResult UpdateAsync([FromBody] TMapUpdate mapModel)
        {
            var model = _mapper.Map<T>(mapModel);
            var response = _baseService.UpdateAsync(model).Result;
            return Ok(response);
        }
        [HttpDelete("DeleteAsync")]
        public virtual IActionResult DeleteAsync(int id)
        {
            var response = _baseService.DeleteAsync(id).Result;
            return Ok(response);
        }
    }
}
