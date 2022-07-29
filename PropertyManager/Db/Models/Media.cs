
using System;
namespace PropertyManager.Models
{
	public enum MediaTypes
    {
		Photo,
		Video
    }


	public class Media
	{
		public long Id { get; set; }
		public MediaTypes MediaType { get; set; }
		public byte[] Data { get; set; }
		
		public string FileType { get; set; }
		
		public long PropertyId { get; set; }
		public Property Property { get; set; }
	}
}

