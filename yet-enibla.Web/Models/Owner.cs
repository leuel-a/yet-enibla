using System.ComponentModel.DataAnnotations;

namespace yet_enibla.Web.Models;

public class Owner
{
    [Key, Required]
    public int Id { get; set; }

    [Required, StringLength(127)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(127)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress()]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(127)]
    public string PhoneNumber { get; set; } = string.Empty;
}
