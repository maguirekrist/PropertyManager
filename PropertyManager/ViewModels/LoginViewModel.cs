using System.ComponentModel.DataAnnotations;

namespace PropertyManager.Models;

public class LoginViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}