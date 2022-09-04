using Core.Entities.Interfaces;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBaseService<T> where T : class,IEntity, new()
    {
        Task<IDataResult<T>> AddAsync(T entity);
        Task<IDataResult<T>> UpdateAsync(T entity);
        Task<IDataResult<T>> GetByIdAsync(int id, bool includeRelationShips = false);
        Task<IDataResult<List<T>>> GetAllAsync(bool includeRelationShips = false,Expression<Func<T, bool>> filter = null);
        Task<IResult> DeleteAsync(int id);
    }
}
