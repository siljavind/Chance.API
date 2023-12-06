using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Chance.Repo.Interfaces;

namespace Chance.Repo.Models;


[Index(nameof(Title), IsUnique = true)]
public class Background : IGeneric
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [JsonIgnore]
    public List<Skill> Skills { get; set; } = [];

    [JsonIgnore]
    public List<Character> Characters { get; set; } = [];
}