using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.Repo.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public Role Role { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; } = [];
}

public enum Role
{
    Admin,
    User
}
