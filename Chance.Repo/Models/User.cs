using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Chance.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

    public string PasswordHash { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];

    public void SetPassword(string password)
    {
        var hasher = new PasswordHasher<User>();
        PasswordHash = hasher.HashPassword(this, password);
    }
    public bool CheckPassword(string password)
    {
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(this, PasswordHash, password);
        return result == PasswordVerificationResult.Success;
    }
}

public enum Role
{
    Admin,
    User
}
