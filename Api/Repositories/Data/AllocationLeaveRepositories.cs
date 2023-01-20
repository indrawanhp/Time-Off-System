using Api.Contexts;
using Api.Models;

namespace Api.Repositories.Data
{
    public class AllocationLeaveRepositories : GeneralRepository<AllocationLeave, int>
    {
        public AllocationLeaveRepositories(MyContext context) : base(context)
        {
        }
    }
}
