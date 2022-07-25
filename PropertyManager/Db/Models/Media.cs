
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
		public string url { get; set; }

		public Media()
		{
		}
	}
}

