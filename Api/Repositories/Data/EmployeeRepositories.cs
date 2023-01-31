using Api.Contexts;
using Api.Models;
using Api.ViewModels;
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
        return (from manager in _context.Employees
                join employee in _context.Employees on manager.Id equals employee.ManagerId
                join jobplacement in _context.JobPlacements on employee.Id equals jobplacement.EmployeeId
                join job in _context.Jobs on jobplacement.JobId equals job.Id
                join department in _context.Departments on jobplacement.DepartmentId equals department.Id
                select new MEmployeeVM
                {
                    EmployeeId = employee.Id,
                    Name = employee.FirstName+" "+employee.LastName,
                    ManagerName = manager.FirstName+" "+manager.LastName,
                    PlacementId = jobplacement.Id,
                    Job = job.Name,
                    Department = department.Name,
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

    public IEnumerable<ManagerNameVM> ManagerName()
    {
        return (from e in _context.Employees
                join a in _context.Accounts on e.Id equals a.EmployeeId
                join ar in _context.AccountRoles on a.EmployeeId equals ar.AccountId
                join r in _context.Roles on ar.RoleId equals r.Id
                where r.Name == "Manager"
                select new ManagerNameVM
                {
                    IdManager = e.Id,
                    ManagerName = e.FirstName + " " + e.LastName
                }).ToList();
    }

    public IEnumerable<GetSubordinateVM> SubordinateManager()
    {
		return (from m in _context.Employees
				join e in _context.Employees on m.Id equals e.ManagerId
				group e by m into managerGroup
				select new GetSubordinateVM
				{
					ManagerId = managerGroup.Key.Id,
					ManagerName = managerGroup.Key.FirstName + " " + managerGroup.Key.LastName,
					Subordinates = managerGroup.Count()
				}).ToList();
	}
}