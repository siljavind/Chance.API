using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Models;

[Index(nameof(Title), IsUnique = true)]
public class User : IGeneric
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    public string Title { get; set; }

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
