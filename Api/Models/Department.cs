using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_departments")]
public class Department
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name")]
    public string Name { get; set; }
    [Column("address")]
    public string Address { get; set; }

    //Relation 
    [JsonIgnore]
    public ICollection<JobPlacements>? Placements { get; set; }

}
