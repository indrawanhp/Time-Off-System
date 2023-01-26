using Api.Contexts;
using Api.Handlers;
using Api.Models;
using Api.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Api.Repositories.Data;

public class AccountRepositories : GeneralRepository<Accounts, int>
{
    private MyContext _context;
    public AccountRepositories(MyContext context) : base(context)
    {
        _context = context;
    }

    public int Register(RegisterVM register)
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

        AccountRoles accountRoles = new AccountRoles()
        {
            AccountId = account.EmployeeId,
            RoleId = register.RoleId
        };
        _context.AccountRoles.Add(accountRoles);
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

    public IEnumerable<MAccountVM> AccountMaster()
    {
        var results =(from a in _context.Accounts
                      join  e in _context.Employees on a.EmployeeId equals e.Id
                      join ar in _context.AccountRoles on a.EmployeeId equals ar.AccountId
                      join r in _context.Roles on ar.RoleId equals r.Id
                      select new MAccountVM
                      {
                          EmployeeId = e.Id,
                          FullName = e.FirstName + " " + e.LastName,
                          Email = a.Email,
                          AccountRoleId = ar.Id,
                          Roles = r.Name
                      }).ToList();
        return results;
    }

    public int ChangePassword(ChangePasswordVM changePasswordVM)
    {
        bool isPasswordCorrect = false;
        int result = 0;

        var data = _context.Accounts
            .FirstOrDefault(model => model.EmployeeId.Equals(changePasswordVM.EmployeeId));

        if (data != null)
        {
            isPasswordCorrect = Hashing.ValidatePassword(changePasswordVM.OldPassword, data.Password);

            if (isPasswordCorrect)
            {
                var newData = _context.Accounts.Find(data.EmployeeId);

                newData.Password = Hashing.HashPassword(changePasswordVM.NewPassword);

                _context.Accounts.Update(newData);
                result = _context.SaveChanges();

                return result;
            }

            return result;
        }

        return result;
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

    public int userID(string email)
    {
        return _context.Accounts.SingleOrDefault(e => e.Email == email).EmployeeId;
    }

    public List<string> UserRoles(string email)
    {
        var getRoles = (from a in _context.Accounts
                       join ar in _context.AccountRoles on a.EmployeeId equals ar.AccountId
                       join r in _context.Roles on ar.RoleId equals r.Id
                       where email == a.Email
                       select r.Name).ToList();
        return getRoles;
    }/*

    public int EditAccountMaster(EditAccountMassterVM editAccountMassterVM)
    {
        int result = 0;

        var data = _context.Accounts
            .FirstOrDefault(model => model.EmployeeId.Equals(editAccountMassterVM.EmployeeId));
        var dataR = _context.AccountRoles
            .FirstOrDefault(model => model.AccountId.Equals(editAccountMassterVM.EmployeeId));

        if (data != null)
        {
            var newDataAccount = _context.Accounts.Find(data.EmployeeId);
            
            if (!CheckEmail(editAccountMassterVM.Email))
            {
                return 0; // Email atau Password sudah terdaftar
            }
            newDataAccount.EmployeeId = editAccountMassterVM.EmployeeId;
            newDataAccount.Email = editAccountMassterVM.Email;
            newDataAccount.Password = Hashing.HashPassword(editAccountMassterVM.Password);
            _context.Accounts.Update(newDataAccount);
            _context.SaveChanges();

            var newDataAccountRole = _context.AccountRoles.Find(dataR.Id);
            newDataAccountRole.AccountId = editAccountMassterVM.EmployeeId;
            newDataAccountRole.RoleId = editAccountMassterVM.Role;
            _context.AccountRoles.Update(newDataAccountRole);
            _context.SaveChanges();

            return 1;
           
        }

        return result;
    }*/
}
