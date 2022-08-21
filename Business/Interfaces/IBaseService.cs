using Core.Entities.Interfaces;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IBaseService<T> where T : class,IEntity, new()
    {
        Task<IResult> AddAsync(T entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IDataResult<T>> GetByIdAsync(int id, bool includeRelationShips = false);
        Task<IDataResult<List<T>>> GetAllAsync(bool includeRelationShips = false);
        Task<IResult> DeleteAsync(int id);
    }
}
