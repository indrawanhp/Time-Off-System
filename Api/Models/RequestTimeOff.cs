using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_req_time_off")]
public class RequestTimeOff
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("employee_id")]
    public int EmployeeId { get; set; }
    [Required, Column("start_date")]
    public DateTime StartDate { get; set; }
    [Required, Column("end_date")]
    public DateTime EndDate { get; set; }
    [Column("duration")]
    public int Duration { get; set; }
    [Column("allocation_id")]
    public int AllocationId { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("status")]
    public Status Status { get; set; } = Status.Request;
    [Column("remark")]
    public string? Remark { get; set; }
    [Column("is_publish")]
    public bool isPublish { get; set; } = false;

    //Relations
    [ForeignKey(nameof(EmployeeId))]
    [JsonIgnore]
    public Employee? Employee { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(AllocationLeave))]
    public AllocationLeave? allocationLeave { get; set; }
}

public enum Status
{
    Request, Approved, Refused
}
