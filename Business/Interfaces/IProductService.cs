using Core.Utilities.Results;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService : IBaseService<Product>
    {
        Task<IResult> UpdateAccountByIdAsync(Product entity,int accountId,string role=null);
    }
}
