using Api.Models;
using System.Text.Json.Serialization;

namespace Api.ViewModels.Employee;

public class EmployeeRequestVM
{
    public int RequestId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    public string Description { get; set; }
    public string Remark { get; set; }
    public Status Status { get; set; }
    public bool IsPublish { get; set; }

}
