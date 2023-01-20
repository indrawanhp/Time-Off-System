using Api.Contexts;
using Api.Handlers;
using Api.Models;
using Api.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Accounts, int>
    {
        private MyContext _context;
        private DbSet<Accounts> _accounts;

        public AccountRepositories(MyContext context) : base(context)
        {
            _context = context;
            _accounts = context.Set<Accounts>();
        }
    }
}
