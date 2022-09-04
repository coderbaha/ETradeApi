using Business.Interfaces;
using Core.Entities.Interfaces;
using Core.Repository;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseManager<T> : IBaseService<T> where T : class, IEntity, new()
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseManager(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<IDataResult<T>> AddAsync(T entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(x => x.Id == id);
        }

        public async Task<IDataResult<List<T>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<T, bool>> filter = null)
        {
            return await _baseRepository.GetAllAsync(includeRelationShips,filter);
        }

        public async Task<IDataResult<T>> GetByIdAsync(int id, bool includeRelationShips = false)
        {
            return await _baseRepository.GetByIdAsync(x => x.Id == id, includeRelationShips);
        }

        public async Task<IDataResult<T>> UpdateAsync(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
