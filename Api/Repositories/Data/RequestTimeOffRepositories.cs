using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class RequestTimeOffRepositories : GeneralRepository<RequestTimeOff, int>
{
    public RequestTimeOffRepositories(MyContext context) : base(context)
    {
    }
}
