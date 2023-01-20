using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class DepartmentRepositories : GeneralRepository<Department, int>
{
    public DepartmentRepositories(MyContext context) : base(context)
    {
    }
}
