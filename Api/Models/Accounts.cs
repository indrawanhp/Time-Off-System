using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_m_accounts")]
public class Accounts
{
    [Key, Column("employee_id")]
    public int EmployeeId { get; set; }
    [Required, Column("email")]
    public string Email { get; set; }
    [Required, Column("password")]
    public string Password { get; set; }


    //Relations
    [JsonIgnore]
    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }
    [JsonIgnore]
    public ICollection<AccountRoles>? AccountRoles { get; set; }
}
