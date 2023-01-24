using Api.Contexts;
using Api.Models;
using Api.ViewModels.Employee;

namespace Api.Repositories.Data;

public class EmployeeRepositories : GeneralRepository<Employee, int>
{
    private MyContext _context;
    public EmployeeRepositories(MyContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<EmployeeRequestVM> EmployeeRequest(int id, Status status)
    {
        return (from e in _context.Employees
                join al in _context.AllocationsLeave on e.Id equals al.EmployeeId
                join req in _context.RequestTimeOffs on e.Id equals req.EmployeeId
                where e.Id == id
                where req.Status == status
                select new EmployeeRequestVM
                {
                    RequestId = req.Id,
                    Name = e.FirstName + " " + e.LastName,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                    Duration = req.Duration,
                    Description = req.Description,
                    Status = req.Status,
                    IsPublish = req.isPublish
                }).ToList();
    }
}
