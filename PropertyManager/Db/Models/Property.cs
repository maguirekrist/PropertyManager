
namespace PropertyManager.Models
{
	public class Property
	{
		public long Id { get; protected set; }
		public DateTime CreatedOn { get; protected init; }
		public string Title { get; set; }
	}
}