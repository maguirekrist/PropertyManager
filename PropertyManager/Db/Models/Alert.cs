using PropertyManager.Utility;

namespace PropertyManager.Models;

public class Alert
{
    public long Id { get; set; }
    public Priority Priority { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}