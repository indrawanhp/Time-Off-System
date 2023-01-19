﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_allocations_leave")]
public class AllocationLeave
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("employee_id")]
    public int EmployeeId { get; set; }
    [Required, Column("remaining")]
    public int Remaining { get; set; }

    //Relation
    [JsonIgnore]
    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }

    [JsonIgnore]
    public RequestTimeOff? RequestTimeOff { get; set; }
}
