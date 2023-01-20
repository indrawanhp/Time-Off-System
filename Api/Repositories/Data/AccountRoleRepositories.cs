using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class AccountRoleRepositories : GeneralRepository<AccountRoles, int>
{
    public AccountRoleRepositories(MyContext context) : base(context)
    {
    }
}
