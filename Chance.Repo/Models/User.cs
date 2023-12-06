using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Models;

[Index(nameof(Username), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Role is required")]
    public Role Role { get; set; } = Role.User;

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];
}

public enum Role
{
    Admin,
    User
}
