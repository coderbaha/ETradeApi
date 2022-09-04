using Core.Constant;
using Core.Entities.Interfaces;
using Core.Repository.EntityFramework;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class ProductDal : IProductDal
    {
        public IQueryable<Product> QueryInclude => QueryInclude
           .Include(x => x.Category)
            .Include(x => x.Account);
        public ProductDal()
        {

        }
        public async Task<IDataResult<Product>> AddAsync(Product entity)
        {
            using (var context = new DatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return new SuccessDataResult<Product>(entity, Messages.Added("Category"));
            }
        }
        private bool checkedRecord(string record, int accountId = 0,string role=null)
        {
            record = record?.Trim().ToLower();
            using (var context = new DatabaseContext())
            {
                if (accountId != 0)
                {
                    return context.Products.Any(x => x.Name.ToLower() == record && (role == "Admin" || x.AccountId == accountId && role != "Admin"));
                }
                return context.Products.Any(x => x.Name.ToLower() == record);
            }   
        }

        public async Task<IResult> UpdateAccountByIdAsync(Product entity, int accountId,string role=null)
        {
            if (checkedRecord(entity.Name,accountId,role))
            {
                return new ErrorDataResult<Product>(Messages.Exist("Product name"));
            }
            using (var context = new DatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Updated("Product"));
            }
        }

        public async Task<IDataResult<Product>> UpdateAsync(Product entity)
        {
            using (var context = new DatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessDataResult<Product>(entity,Messages.Updated("Product"));
            }
        }

        public async Task<IDataResult<Product>> GetByIdAsync(Expression<Func<Product, bool>> filter, bool includeRelationShips = false)
        {
            using (var context = new DatabaseContext())
            {
                if (includeRelationShips)
                {
                    var model = await QueryInclude.FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<Product>(model, Messages.Listed("Product"));

                    return new ErrorDataResult<Product>(Messages.NotListed("Product"));
                }
                else
                {
                    var model = await context.Set<Product>().FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<Product>(model, Messages.Listed("Product"));
                    return new ErrorDataResult<Product>(Messages.NotListed("Product"));
                }
            }
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                if (includeRelationShips)
                {
                    var includeRelationShipsList = filter != null ?
                        QueryInclude.Where(filter).ToList() :
                        QueryInclude.ToList();
                    return new SuccessDataResult<List<Product>>(includeRelationShipsList, Messages.Listed("Product"));
                }
                var list = filter != null ?
                context.Set<Product>().Where(filter).ToList() :
                context.Set<Product>().ToList();
                return new SuccessDataResult<List<Product>>(list, Messages.Listed("Product"));
            }
        }

        public async Task<IResult> DeleteAsync(Expression<Func<Product, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                var model = context.Set<Product>().FirstOrDefault(filter);
                if (model != null)
                {
                    var deletedEntity = context.Entry(model);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return new SuccessResult(Messages.Deleted("Product"));
                }
                return new ErrorResult(Messages.NotDeleted("Product"));
            }
        }
    }
}
