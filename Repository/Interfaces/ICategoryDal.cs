using Core.Repository;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace Repository.Interfaces
{
    public interface ICategoryDal
    {
        Task<IDataResult<Category>> AddAsync(Category entity);
        Task<IDataResult<Category>> UpdateAsync(Category entity);
        Task<IDataResult<Category>> GetByIdAsync(Expression<Func<Category, bool>> filter, bool includeRelationShips = false);
        Task<IDataResult<List<Category>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Category, bool>> filter = null);
        Task<IResult> DeleteAsync(Expression<Func<Category, bool>> filter);
    }
}
