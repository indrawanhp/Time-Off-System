using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class JobRepositories : GeneralRepository<Jobs, int>
{
    public JobRepositories(MyContext context) : base(context)
    {
    }
}
