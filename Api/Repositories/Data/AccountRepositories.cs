using Api.Contexts;
using Api.Handlers;
using Api.Models;
using Api.ViewModels;


namespace Api.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Accounts, int>
    {
        private readonly MyContext _context;
        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
        }
        public int Login (LoginVM login)
        {
            var result = _context.Accounts.Join(_context.Employees, a => a.EmployeeId, e => e.Id, (a, e) =>
            new LoginVM
            {
                Email = a.Email,
                Password = a.Password
            }).SingleOrDefault(c => c.Email == login.Email);

            if(result == null)
            {
                return 0;
            }
            if(!Hashing.ValidatePassword(login.Password, result.Password))
            {
                return 1;
            }
            return 2;
        }
    }
}
