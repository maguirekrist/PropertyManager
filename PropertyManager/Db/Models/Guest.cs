namespace PropertyManager.Models;

public class Guest
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
        
    public DateTime LastLoggedIn { get; set; }
    public DateTime CreatedOn { get; set; }
    
    public long ResidentId { get; set; }
}