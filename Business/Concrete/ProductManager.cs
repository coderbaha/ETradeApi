using Business.Interfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Repository.Concrete;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService

    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IDataResult<Product>> AddAsync(Product entity)
        {
            return await _productDal.AddAsync(entity);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            return await _productDal.DeleteAsync(x => x.Id == id);
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Product, bool>> filter = null)
        {
            return await _productDal.GetAllAsync(includeRelationShips, filter);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id, bool includeRelationShips = false)
        {
            return await _productDal.GetByIdAsync(x => x.Id == id, includeRelationShips);
        }

        public async Task<IResult> UpdateAccountByIdAsync(Product entity, int accountId,string role=null)
        {
            return await _productDal.UpdateAccountByIdAsync(entity, accountId, role);
            //return new SuccessResult(response.Result.Message);
        }

        public async Task<IDataResult<Product>> UpdateAsync(Product entity)
        {
            return await _productDal.UpdateAsync(entity);
        }
    }
}
