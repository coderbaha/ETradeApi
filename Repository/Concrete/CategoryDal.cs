using Core.Repository.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System.Linq;

namespace Repository.Concrete
{
    public class CategoryDal : EfBaseRepository<Category, DatabaseContext>, ICategoryDal
    {
        public override IQueryable<Category> QueryInclude => base.QueryInclude
            .Include(x => x.Products);
        public CategoryDal(DatabaseContext context) : base(context)
        {

        }
    }
}
