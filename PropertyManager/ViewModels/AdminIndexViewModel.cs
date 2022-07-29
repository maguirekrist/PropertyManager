namespace PropertyManager.Models;

public class AdminIndexViewModel
{
    public Alert? ActiveAlert { get; set; }

    public List<Resident> Residents { get; set; }
    
    public List<Property> Properties { get; set; }
}