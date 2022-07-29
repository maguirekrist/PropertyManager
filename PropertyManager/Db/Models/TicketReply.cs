namespace PropertyManager.Models;

public class TicketReply
{
    public long Id { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public Resident CreatedBy { get; set; }
}