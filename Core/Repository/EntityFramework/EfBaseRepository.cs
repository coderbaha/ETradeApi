using Core.Constant;
using Core.Entities.Interfaces;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Repository.EntityFramework
{
    public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        protected TContext _context;
        private DbSet<TEntity> DbSet => _context.Set<TEntity>();
        public virtual IQueryable<TEntity> QueryInclude => DbSet;
        public EfBaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<IResult> AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Added(typeof(TEntity).Name));
            }
        }

        public async Task<IResult> DeleteAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var model = context.Set<TEntity>().FirstOrDefault(filter);
                if (model != null)
                {
                    var deletedEntity = context.Entry(model);
                    deletedEntity.State = EntityState.Deleted;
                    await context.SaveChangesAsync();
                    return new SuccessResult(Messages.Deleted(typeof(TEntity).Name));
                }
                return new ErrorResult(Messages.NotDeleted(typeof(TEntity).Name));
            }
        }

        public async Task<IDataResult<List<TEntity>>> GetAllAsync(bool includeRelationShips = false, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                if (includeRelationShips)
                {
                    var includeRelationShipsList = filter != null ?
                        QueryInclude.Where(filter).ToList() :
                        QueryInclude.ToList();
                    return new SuccessDataResult<List<TEntity>>(includeRelationShipsList, Messages.Listed(typeof(TEntity).Name));
                }
                var list = filter != null ?
                context.Set<TEntity>().Where(filter).ToList() :
                context.Set<TEntity>().ToList();
                return new SuccessDataResult<List<TEntity>>(list, Messages.Listed(typeof(TEntity).Name));
            }
        }

        public async Task<IDataResult<TEntity>> GetByIdAsync(Expression<Func<TEntity, bool>> filter, bool includeRelationShips = false)
        {
            using (var context = new TContext())
            {
                if (includeRelationShips)
                {
                    var model = await QueryInclude.FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<TEntity>(model, Messages.Listed(typeof(TEntity).Name));

                    return new ErrorDataResult<TEntity>(Messages.NotListed(typeof(TEntity).Name));
                }
                else
                {
                    var model = await context.Set<TEntity>().FirstOrDefaultAsync(filter);
                    if (model != null)
                        return new SuccessDataResult<TEntity>(model, Messages.Listed(typeof(TEntity).Name));

                    return new ErrorDataResult<TEntity>(Messages.NotListed(typeof(TEntity).Name));
                }
            }
        }

        public async Task<IResult> UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return new SuccessResult(Messages.Updated(typeof(TEntity).Name));
            }
        }
    }
}
