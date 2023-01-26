using Api.Contexts;
using Api.Models;
using Api.ViewModels;
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

        public IEnumerable<AllocationLeaveMasterVM> AllocationLeaveMasters()
        {
            var results = (from e in _context.Employees
                           join jp in _context.JobPlacements on e.Id equals jp.EmployeeId
                           join j in _context.Jobs on jp.JobId equals j.Id
                           join d in _context.Departments on jp.DepartmentId equals d.Id
                           join al in _context.AllocationsLeave on e.Id equals al.EmployeeId
                           select new AllocationLeaveMasterVM
                           {
                               EmployeeId = e.Id,
                               fullName = e.FirstName + " " + e.LastName,
                               Jabatan = j.Name,
                               Department = d.Name,
                               AllocationsLeaveId = al.Id,
                               SisaCuti = al.Remaining
                           }).ToList();
            return results;
        }

        public IEnumerable<AllocationLeave> GetEmployee(int id)
        {
            var result = (from leave in _context.AllocationsLeave
                          where leave.EmployeeId == id
                          select leave).ToList();
            return result;
        }
    }
}
