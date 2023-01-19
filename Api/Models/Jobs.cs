using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_jobs")]
public class Jobs
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name")]
    public string Name { get; set; }
    [Column("min_salary")]
    public int MinSalary { get; set; }
    [Column("max_salary")]
    public int MaxSalary { get; set;}

    //Relation
    [JsonIgnore]
    public ICollection<JobPlacements>? JobPlacements { get; set; }
}
