using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Chance.API.Models;

public class User //TODO Add Data Annotations to all models
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; }

    [JsonIgnore]
    public List<Character> Characters { get; } = [];

}