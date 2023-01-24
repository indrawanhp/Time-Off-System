using Api.Contexts;
using Api.Models;
using System.Security.Cryptography;

namespace Api.Repositories.Data
{
    public class AllocationLeaveRepositories : GeneralRepository<AllocationLeave, int>
    {
        private MyContext _context;
        public AllocationLeaveRepositories(MyContext context) : base(context)
        {
            _context = context;
        }

        public AllocationLeave GetEmployee(int id)
        {
            var result = (from leave in _context.AllocationsLeave
                          where leave.EmployeeId == id
                          select leave).SingleOrDefault();
            return result;
                    
        }
    }
}
