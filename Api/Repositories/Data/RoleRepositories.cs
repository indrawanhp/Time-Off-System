using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class RoleRepositories : GeneralRepository<Roles, int>
{
    public RoleRepositories(MyContext context) : base(context)
    {
    }
}
