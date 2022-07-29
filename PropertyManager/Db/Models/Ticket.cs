using PropertyManager.Utility;

namespace PropertyManager.Models;

public class Ticket
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; } = Priority.LOW;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime UpdatedOn { get; set; }
    
    public IEnumerable<TicketReply> Replies { get; set; }
    public Resident CreatedBy { get; set; }
    
}