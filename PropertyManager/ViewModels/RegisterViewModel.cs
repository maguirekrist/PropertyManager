using PropertyManager.Utility;
using System.ComponentModel.DataAnnotations;

namespace PropertyManager.Models;

public class RegisterViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [MinLength(4)]
    public string Password { get; set; }
}