
using PropertyManager.Utility;

namespace PropertyManager.Models
{
	public class Property
	{
		public long Id { get; init; }
		public DateTime CreatedOn { get; init; } = DateTime.Now;
		public DateTime UpdatedOn { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public Condition Condition { get; set; }
		public IEnumerable<Media> Mediae { get; set; }
		
		
		public long ResidentId { get; set; }
		public Resident Resident { get; set; }
	}
}