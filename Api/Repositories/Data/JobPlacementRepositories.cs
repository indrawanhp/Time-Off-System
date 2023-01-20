using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data;

public class JobPlacementRepositories : GeneralRepository<JobPlacements, int>
{
    public JobPlacementRepositories(MyContext context) : base(context)
    {
    }
}
