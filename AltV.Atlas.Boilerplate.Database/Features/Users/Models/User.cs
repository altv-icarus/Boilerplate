using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltV.Atlas.Boilerplate.Database.Features.Users.Models;

[Table("users")]
public class User
{
    [Key, DatabaseGenerated( DatabaseGeneratedOption.Identity )]
    public uint Id { get; set; }
    public required string Name { get; set; }
    public string Password { get; set; }
    public required string IpAddress { get; set; }
    public required uint Kills { get; set; }
    public required uint Deaths { get; set; }
}