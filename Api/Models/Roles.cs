using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_roles")]
public class Roles
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("name")]
    public string Name { get; set; }

    //Relations
    [JsonIgnore]
    public ICollection<AccountRoles>? AccountRoles { get; set; }
}
