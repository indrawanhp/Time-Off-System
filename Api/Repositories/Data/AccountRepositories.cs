using Api.Contexts;
using Api.Handlers;
using Api.Models;
using Api.ViewModels;

namespace Api.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Accounts, int>
    {
        private MyContext _context;
        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
        }

        public int Register(Accounts register)
        {

            if (!CheckEmail(register.Email))
            {
                return 0; // Email atau Password sudah terdaftar
            }

            Accounts account = new Accounts()
            {
                EmployeeId = register.EmployeeId,
                Email = register.Email,
                Password = Hashing.HashPassword(register.Password),
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();

            return 1;
        }

        public int Login(LoginVM loginVM)
        {
            var result = (from a in _context.Accounts
                          select new LoginVM
                          {
                              Email = a.Email,
                              Password = a.Password,
                          }).SingleOrDefault(c => c.Email == loginVM.Email);
            if(result == null)
            {
                return 0; //Email Already Exist
            }
            if(!Hashing.ValidatePassword(loginVM.Password, result.Password))
            {
                return 1; //Wrong Password
            }
            return 2; //Email and Password is match
        }


        private bool CheckEmail(string email)
        {
            var duplicate = _context.Accounts.Where(a => a.Email == email).ToList();

            if (duplicate.Any())
            {
                return false; // Email atau Password sudah ada
            }
            return true; // Email dan Password belum terdaftar
        }

        public List<string> UserRoles(string email)
        {
            var getRoles = (from a in _context.Accounts
                           join ar in _context.AccountRoles on a.EmployeeId equals ar.AccountId
                           join r in _context.Roles on ar.RoleId equals r.Id
                           where email == a.Email
                           select r.Name).ToList();
            return getRoles;
        }
    }
}
