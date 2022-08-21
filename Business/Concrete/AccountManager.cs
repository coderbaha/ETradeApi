using Business.Interfaces;
using Core.Utilities.Results;
using Entities.Concrete;
using Repository.Interfaces;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDal;
        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }
        public async Task<IResult> AccountSignUp(Account model)
        {
            model.UserName = model.UserName?.Trim().ToLower();
            var response = await _accountDal.AccountSignUp(model);
            return new Result(response.Success, response.Message);
        }

        public async Task<DataResult<Account>> Login(Login model)
        {
            model.UserName = model.UserName?.Trim().ToLower();
            var response = await _accountDal.Login(model);
            return new DataResult<Account>(response.Data,response.Success,response.Message);
        }

        public async Task<IResult> Register(Account model)
        {
            model.UserName = model.UserName?.Trim().ToLower();
            var response = await _accountDal.Register(model);
            return new Result(response.Success, response.Message);
        }
    }
}
