using Api.Models;

namespace Api.ViewModels.Admin;

public class MEmployeeVM
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string ManagerName { get; set; }
    public int PlacementId { get; set; }
    public string Job { get; set; }
    public string Department { get; set; }
}
