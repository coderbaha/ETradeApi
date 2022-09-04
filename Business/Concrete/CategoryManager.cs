using Business.Interfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IDataResult<Category>> AddAsync(Category entity)
        {
            return await _categoryDal.AddAsync(entity);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            return await _categoryDal.DeleteAsync(x => x.Id == id);
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Category, bool>> filter = null)
        {
            return await _categoryDal.GetAllAsync(includeRelationShips, filter);
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id, bool includeRelationShips = false)
        {
            return await _categoryDal.GetByIdAsync(x => x.Id == id, includeRelationShips);
        }

        public async Task<IDataResult<Category>> UpdateAsync(Category entity)
        {
            return await _categoryDal.UpdateAsync(entity);
        }
    }
}
