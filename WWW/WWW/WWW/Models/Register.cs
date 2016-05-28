using System;

namespace Registering
{
	public class Register
	{
		string UserLogin;
		string UserPassword;

		public Register (string Login, string Password)
		{
			UserLogin = Login;
			UserPassword = Password;
		}

		public bool checkDatas(){

			if (UserLogin.Length < 3 || UserPassword.Length < 3)
				return false;

			return true;
		}

		public bool RegisterInit()
		{
			if(!checkDatas ())
				return false;

			if (isBusy ())
				return false;


			UserDatabaseController udb = new UserDatabaseController ();
			PasswordHasher Hasher = new PasswordHasher ();

			string query = "INSERT INTO users (login, pass, perm) VALUES('" + UserLogin + "', '" + Hasher.HashPassword (UserPassword) + "', '0')";

			udb.Insert (query);

			return true;
		}

		public bool isBusy()
		{

			UserDatabaseController udb = new UserDatabaseController ();

			if (udb.ReturnUserId (UserLogin) == -1)
				return false;

			return true;

		}
	}
}




