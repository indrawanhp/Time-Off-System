using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models;

[Table("tb_r_account_roles")]
public class AccountRoles
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Required, Column("account_id")]
    public int AccountId { get; set; }
    [Required, Column("role_id")]
    public int RoleId { get; set; }

    //Relations
    [JsonIgnore]
    [ForeignKey(nameof(AccountId))]
    public Accounts? Accounts { get; set; }
    [JsonIgnore]
    [ForeignKey(nameof(RoleId))]
    public Roles? Roles { get; set; }
}
