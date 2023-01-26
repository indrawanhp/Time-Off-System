using Api.Contexts;
using Api.Models;
using Api.ViewModels;

namespace Api.Repositories.Data;

public class JobPlacementRepositories : GeneralRepository<JobPlacements, int>
{
    private readonly MyContext _context;

    public JobPlacementRepositories(MyContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<MJobPlacementVM> GetMaster()
    {
        return (from jp in _context.JobPlacements
                join e in _context.Employees on jp.EmployeeId equals e.Id
                join d in _context.Departments on jp.DepartmentId equals d.Id
                join j in _context.Jobs on jp.JobId equals j.Id
                select new MJobPlacementVM
                {
                    Name = e.FirstName + " " + e.LastName,
                    Department = d.Name,
                    Job = j.Name,
                    Id = jp.Id
                }).ToList();
    }
}