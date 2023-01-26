using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_employees")]
public class Employee
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("first_name")]
    public string FirstName { get; set; }
    [Required, Column("last_name")]
    public string LastName { get; set; }
    [Required, Column("birth_date")]
    public DateTime BirthDate { get; set; }
    [Required, Column("address")]
    public string Address { get; set; }
    [Required, Column("hire_date")]
    public DateTime HireDate { get; set; }
    [Required, Column("release_date")]
    public DateTime ReleaseDate { get; set; }
    [Column("phone")]
    public string Phone { get; set; }
    [Column("gender")]
    public Gender Gender { get; set; }
    [Column("age")]
    public int Age { get; set; }
    [Column("manager_id")]
    public int ManagerId { get; set; }

    // Relation
    [JsonIgnore]
    public ICollection<JobPlacements>? Placements { get; set; }
    [JsonIgnore]
    public ICollection<RequestTimeOff>? requestTimeOff { get; set; }
    [JsonIgnore]
    public Accounts? accounts { get; set; }
}

public enum Gender
{
    Male, Female
}
