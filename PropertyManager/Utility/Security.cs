using System.Security.Cryptography;

namespace PropertyManager.Utility
{
    public static class Security
    {
		public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passSalt = hmac.Key;
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
			}
		}

		public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return computeHash.SequenceEqual(passwordHash);
			}
		}
	}
}
