using System;

namespace Registering
{
	public class UserLoginField : Fields
	{

		public UserLoginField()
		{
			name = "User Login";
			databaseName = "login";
		}
			
		public bool isBusy(string gValue)
		{

			UserDatabaseController udb = new UserDatabaseController ();

			if (udb.ReturnUserId (gValue) == -1)
				return false;

			return true;

		}

		override public bool validation ( string gValue ) {

			if (gValue.Length < 3 || gValue.Length > 15)
				return false;
			
			if (isBusy (gValue))
				return false; 


			return true;

		}
	}
}

