using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_r_job_placements")]
public class JobPlacements
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("employee_id")]
    public int EmployeeId { get; set; }
    [Column("department_id")]
    public int DepartmentId { get; set; }
    [Column("job_id")]
    public int JobId { get; set; }

    //Relation
    [JsonIgnore]
    [ForeignKey(nameof(EmployeeId))]
    public Employee? employee { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(DepartmentId))]
    public Department? department { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(JobId))]
    public Jobs? jobs { get; set; }
}
