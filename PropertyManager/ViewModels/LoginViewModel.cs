using System.ComponentModel.DataAnnotations;

namespace PropertyManager.Models;

public class LoginViewModel
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
}