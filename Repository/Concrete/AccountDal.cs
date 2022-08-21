using Core.Utilities.Results;
using Entities.Concrete;
using Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class AccountDal : IAccountDal
    {
        private DatabaseContext _db;
        public AccountDal(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IResult> AccountSignUp(Account model)
        {
            if (_db.Accounts.Any(x => x.UserName.ToLower() == model.UserName))
            {
                return new Result(false, "Bu kullanıcı adı kullanılıyor");
            }
            _db.Accounts.Add(model);
            await _db.SaveChangesAsync();
            return new Result(true, "Kayıt başarılı");
        }

        public async Task<DataResult<Account>> Login(Login model)
        {
            var account = _db.Accounts.SingleOrDefault(x => x.UserName.ToLower() == model.UserName && x.Password == model.Password);
            int a = 3;
            if (account == null)
            {
                return new ErrorDataResult<Account>(account, "Başarısız");
            }
            return new SuccessDataResult<Account>(account,"Başarılı");
        }

        public async Task<IResult> Register(Account model)
        {
            if (_db.Accounts.Any(x => x.UserName.ToLower() == model.UserName))
            {
                return new Result(false, "Bu kullanıcı adı kullanılıyor");
            }
            _db.Accounts.Add(model);
            await _db.SaveChangesAsync();
            return new Result(true, "Kayıt başarılı");
        }
    }
}
