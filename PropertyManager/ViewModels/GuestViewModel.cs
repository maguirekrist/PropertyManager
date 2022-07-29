using System.ComponentModel.DataAnnotations;

namespace PropertyManager.Models;

public class GuestViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.Password)]
    [MinLength(4)]
    public string Password { get; set; }
}