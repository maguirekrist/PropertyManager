using PropertyManager.Utility;
using PropertyManager.Utility.Validation;

namespace PropertyManager.Models;

public class EditPropertyViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public Condition Condition { get; set; }
    [FileOrVideo]
    public IFormFileCollection? FormFiles { get; set; }
    public string? Description { get; set; }
}