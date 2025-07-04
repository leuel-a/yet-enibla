using System.Text.Json;
using System.ComponentModel.DataAnnotations;

namespace yet_enibla.Web.Models;

public class Restaurant
{
    [Key, Required]
    public int Id { get; set; }

    [Required]
    [StringLength(127)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(455)]
    public string Description { get; set; } = string.Empty;

    [Required, StringLength(127)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required, Url]
    public string Website { get; set; } = string.Empty;

    [Required, StringLength(255)]
    public string Address { get; set; } = string.Empty;

    [Required, StringLength(255)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Country { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Name} ({City}, {Country})";
    }

    public string ToJson() => 
        JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

    public void Deconstruct(out string? name, out string? city, out string? country)
    {
        name = Name;
        city = City;
        country = Country;
    }
}
