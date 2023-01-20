using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class EmployeeRepositories : GeneralRepository<Employee, int>
{
    public EmployeeRepositories(MyContext context) : base(context)
    {
    }
}
