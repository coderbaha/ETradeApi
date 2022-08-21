using Core.Entities.Interfaces;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IBaseRepository<T> where T : class,IEntity, new()
    {
        Task<IResult> AddAsync(T entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IDataResult<T>> GetByIdAsync(Expression<Func<T, bool>> filter, bool includeRelationShips = false);
        Task<IDataResult<List<T>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<T, bool>> filter = null);
        Task<IResult> DeleteAsync(Expression<Func<T, bool>> filter);
    }
}
