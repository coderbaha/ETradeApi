using Core.Utilities.Results;
using Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAccountService
    {
        Task<IResult> AccountSignUp(Account model);
        Task<IResult> Register(Account model);
        Task<DataResult<Account>> Login(Login model);
    }
}
