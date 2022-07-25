namespace PropertyManager.Models;

public class Ticket
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}