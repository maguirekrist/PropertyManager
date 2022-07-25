
using System.Security.Cryptography;

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
		public string PasswordSalt { get; set; }
		
		public ICollection<Property> Properties { get; set; }
	
		public bool isAdmin { get; set; } = false;
		
		public Resident()
		{
			
		}

		public static Resident CreateResident(RegisterViewModel resident)
		{
			CreatePasswordHash(resident.Password, out byte[] passwordHash, out byte[] passSalt);

			return new Resident
			{
				Email = resident.Email,
				FirstName = resident.FirstName,
				LastName = resident.LastName,
				Password = System.Text.Encoding.UTF8.GetString(passwordHash),
				PasswordSalt = System.Text.Encoding.UTF8.GetString(passSalt)
			};
		}
		
		private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computeHash.SequenceEqual(passwordHash);
			}
		}
	}
}
