namespace yet_enibla.Web.Models;

// !(NOTE): an owner can have many restaurants, but a restaurant can have only one owner
public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
