using Api.Contexts;
using Api.Models;
using Api.ViewModels.Admin;
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
                join req in _context.RequestTimeOffs on e.Id equals req.EmployeeId
                join al in _context.AllocationsLeave on req.AllocationId equals al.Id
                where e.Id == id
                where req.Status == status
                select new EmployeeRequestVM
                {
                    RequestId = req.Id,
                    Name = e.FirstName + " " + e.LastName,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                    Duration = req.Duration,
                    AllocationId = req.AllocationId,
                    Description = req.Description,
                    LeaveType = al.Name,
                    Remark = req.Remark,
                    Status = req.Status,
                    IsPublish = req.isPublish
                }).ToList();
    }

    public IEnumerable<MEmployeeVM> MasterEmployee()
    {
        return (from m in _context.Employees
                join e in _context.Employees on m.Id equals e.ManagerId
                select new MEmployeeVM
                {
                    Id = e.Id,
                    Name = e.FirstName + " " + e.LastName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Gender = e.Gender,
                    Age = e.Age,
                    ManagerName = m.FirstName + " " + m.LastName,
                }).ToList();
    }

    public IEnumerable<EmployeeRequestVM> ManangeEmploye(int id, Status status)
    {
        return (from e in _context.Employees
                join req in _context.RequestTimeOffs on e.Id equals req.EmployeeId
                join al in _context.AllocationsLeave on req.AllocationId equals al.Id
                where e.ManagerId == id & req.isPublish == true & req.Status == status
                select new EmployeeRequestVM
                {
                    RequestId = req.Id,
                    Name = e.FirstName + " " + e.LastName,
                    StartDate = req.StartDate,
                    EndDate = req.EndDate,
                    Duration = req.Duration,
                    AllocationId = req.AllocationId,
                    Description = req.Description,
                    LeaveType = al.Name,
                    Remark = req.Remark,
                    Status = req.Status,
                    IsPublish = req.isPublish
                }).ToList();
    }
}
