namespace PropertyManager.Models;

public record PropertyViewModel
{
    public long Id { get; init; }
    public string Title { get; init; }
    
    public DateTime CreatedOn { get; init; } = DateTime.Now;
    public DateTime UpdatedOn { get; set; }
    
    
    
}