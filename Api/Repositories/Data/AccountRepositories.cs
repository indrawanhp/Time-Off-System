using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data
{
    public class AccountRepositories : GeneralRepository<Accounts, int>
    {
        public AccountRepositories(MyContext context) : base(context)
        {
        }
    }
}
