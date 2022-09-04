using Core.Repository;
using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductDal
    {
        Task<IDataResult<Product>> AddAsync(Product entity);
        Task<IDataResult<Product>> UpdateAsync(Product entity);
        Task<IDataResult<Product>> GetByIdAsync(Expression<Func<Product, bool>> filter, bool includeRelationShips = false);
        Task<IDataResult<List<Product>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Product, bool>> filter = null);
        Task<IResult> DeleteAsync(Expression<Func<Product, bool>> filter);
        Task<IResult> UpdateAccountByIdAsync(Product entity,int accountId,string role=null);
    }
}
