using System;

namespace Registering
{
	public class UserPassField : Fields
	{

		public UserPassField()
		{
			name = "User Password";
			databaseName = "pass";
		}

		override public bool validation ( string gValue ) {

			if (gValue.Length < 3 || gValue.Length > 15)
				return false;


			return true;

		}

		override public bool setValue( string gValue, int UserId ) {

			if (!validation (gValue))
				return false;
			

			UserDatabaseController udb = new UserDatabaseController ();
			PasswordHasher Hasher = new PasswordHasher ();

			udb.SetFieldValue (UserId, this, Hasher.HashPassword (gValue)); 

			return true;
		}
	}
}

