using Business.Interfaces;
using Entities.Concrete;
using Repository.Interfaces;

namespace Business.Concrete
{
    public class CategoryManager : BaseManager<Category>, ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal) : base(categoryDal)
        {
            _categoryDal = categoryDal;
        }
    }
}
