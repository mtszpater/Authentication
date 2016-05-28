using System;
using System.Security.Cryptography;

namespace Registering
{
	public class PasswordHasher
	{

		public bool comparePassword(string passNormal, string passHashed){
			string passa = HashPassword(passNormal);
		

			if (passa.CompareTo (passHashed) == 0) {
				return true;
			}

			return false;

		}

		public string HashPassword(string Password) {
			string Salt = "nowyLogin";

			Rfc2898DeriveBytes Hasher = new Rfc2898DeriveBytes(Password,
				System.Text.Encoding.Default.GetBytes(Salt), 10000);
			return Convert.ToBase64String(Hasher.GetBytes(25));
		}
	}
}


