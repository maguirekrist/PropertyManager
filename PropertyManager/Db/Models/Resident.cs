
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace PropertyManager.Models
{
	
	public class Resident
	{
		public long Id { get; set; }
		public string Email { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;

		public string Password { get; set; }

		public IEnumerable<Property> Properties { get; set; }
		public IEnumerable<Ticket> Tickets { get; set; }
		public IEnumerable<Guest> Guests { get; set; }

		public bool isAdmin { get; set; } = false;
		
		public Resident()
		{
			
		}

		public static Resident CreateResident(RegisterViewModel resident)
		{
			
				
			return new Resident
			{
				Email = resident.Email,
				FirstName = resident.FirstName,
				LastName = resident.LastName,
				Password = BCrypt.Net.BCrypt.HashPassword(resident.Password)
			};
		}

		
	}
}
