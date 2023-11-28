using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Chance.Repo.Models;

[Index(nameof(Title), IsUnique = true)]
public class Feature
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    public string? Description { get; set; } // TODO Store the Description as HTML or Markdown

    [JsonIgnore]
    public List<Class> Classes { get; set; } = [];

    [JsonIgnore]
    public List<Race> Races { get; set; } = [];

    [JsonIgnore]
    public List<Subrace> Subraces { get; set; } = [];

}