using Core.Constant;
using Core.Entities.Interfaces;
using Core.Repository.EntityFramework;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs.CategoryDTOs;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        public  IQueryable<Category> QueryInclude => QueryInclude
            .Include(x => x.Products);
        public CategoryDal()
        {
        }

        public async Task<IDataResult<Category>> AddAsync(Category entity)
        {
            using (var context = new DatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return new SuccessDataResult<Category>(entity, Messages.Added("Category"));
            }
        }

        public async Task<IDataResult<Category>> UpdateAsync(Category entity)
        {
            using (var context = new DatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessDataResult<Category>(entity,Messages.Updated("Category"));
            }
        }

        public async Task<IDataResult<Category>> GetByIdAsync(Expression<Func<Category, bool>> filter, bool includeRelationShips = false)
        {
            using (var context = new DatabaseContext())
            {
                if (includeRelationShips)
                {
                    var model = await QueryInclude.FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<Category>(model, Messages.Listed("Category"));

                    return new ErrorDataResult<Category>(Messages.NotListed("Category"));
                }
                else
                {
                    var model = await context.Set<Category>().FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<Category>(model, Messages.Listed("Category"));
                    return new ErrorDataResult<Category>(Messages.NotListed("Category"));
                }
            }
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<Category, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                if (includeRelationShips)
                {
                    var includeRelationShipsList = filter != null ?
                        QueryInclude.Where(filter).ToList() :
                        QueryInclude.ToList();
                    return new SuccessDataResult<List<Category>>(includeRelationShipsList, Messages.Listed("Category"));
                }
                var list = filter != null ?
                context.Set<Category>().Where(filter).ToList() :
                context.Set<Category>().ToList();
                return new SuccessDataResult<List<Category>>(list, Messages.Listed("Category"));
            }
        }

        public async Task<IResult> DeleteAsync(Expression<Func<Category, bool>> filter)
        {
            using (var context = new DatabaseContext())
            {
                var model = context.Set<Category>().FirstOrDefault(filter);
                if (model != null)
                {
                    var deletedEntity = context.Entry(model);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return new SuccessResult(Messages.Deleted("Category"));
                }
                return new ErrorResult(Messages.NotDeleted("Category"));
            }
        }
    }
}
