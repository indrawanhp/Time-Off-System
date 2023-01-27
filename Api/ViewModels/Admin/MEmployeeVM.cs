using Api.Models;

namespace Api.ViewModels.Admin;

public class MEmployeeVM
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public String ManagerName { get; set; }
}
