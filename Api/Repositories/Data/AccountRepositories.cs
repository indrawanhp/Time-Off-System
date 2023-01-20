using Api.Contexts;
using Api.Handlers;
using Api.Models;
using Api.ViewModels;
<<<<<<< HEAD

=======
>>>>>>> main

namespace Api.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Accounts, int>
    {
<<<<<<< HEAD
        private readonly MyContext _context;
=======
        private MyContext _context;
>>>>>>> main
        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public int Register(RegisterVM registerVM)
        {
            if (!CheckEmailPhone(registerVM.Email, registerVM.Phone))
            {
                return 0; // Email atau Password sudah terdaftar
            }
            Employee emp = new Employee()
            {
                FirstName = registerVM.firstName,
                LastName = registerVM.lastName,
                Address = registerVM.Address,
                HireDate = registerVM.HireDate,
                ReleaseDate = registerVM.ReleaseDate,
                Phone = registerVM.Phone,
                Gender = registerVM.Gender,
                Age = registerVM.Age,
                ManagerId = registerVM.Manager
            };
            _context.Employees.Add(emp);
            _context.SaveChanges();

            JobPlacements jp = new JobPlacements()
            {
                EmployeeId = emp.Id,
                DepartmentId = registerVM.DepartmenId,
                JobId = registerVM.JobId
            };
            _context.JobPlacements.Add(jp);
            _context.SaveChanges();

            Accounts ac = new Accounts()
            {
                EmployeeId = emp.Id,
                Email = registerVM.Email,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            _context.Accounts.Add(ac);
            _context.SaveChanges();

            AccountRoles ar = new AccountRoles()
            {
                AccountId = emp.Id,
                RoleId = 1
            };
            _context.AccountRoles.Add(ar);
            _context.SaveChanges();
            return 1;
        }

        private bool CheckEmailPhone(string email, string phone)
        {
            var duplicateEmail = _context.Accounts.Where(a => a.Email == email).ToList();
            var duplicatePhone = _context.Employees.Where(e => e.Phone == phone).ToList();

            if (duplicateEmail.Any() && duplicatePhone.Any())
=======
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
>>>>>>> main
            {
                return false; // Email atau Password sudah ada
            }
            return true; // Email dan Password belum terdaftar
        }

<<<<<<< HEAD
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
            if (!Hashing.ValidatePassword(login.Password, result.Password))
            {
                return 1;
            }
            return 2;
        }

        public List<string> UserRoles(string email)
        {
            var getNIK = _context.Accounts.SingleOrDefault(e => e.Email == email).EmployeeId;
            var getRoles = _context.AccountRoles.Where(ar => ar.AccountId == getNIK)
                                                .Join(_context.Roles, ar => ar.RoleId, r => r.Id, (ar, r) => r.Name)
                                                .ToList();

=======
        public List<string> UserRoles(string email)
        {
            var getRoles = (from a in _context.Accounts
                           join ar in _context.AccountRoles on a.EmployeeId equals ar.Id
                           join r in _context.Roles on ar.RoleId equals r.Id
                           where email == a.Email
                           select r.Name).ToList();
>>>>>>> main
            return getRoles;
        }
    }
}
