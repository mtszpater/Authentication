using System;
using System.Collections.Generic;

namespace Registering
{
	public class UserDatabaseController : DatabaseController
	{
		public UserDatabaseController()
		{
			Initialize ();
		}

		public bool checkPassCompare( string UserLogin, string UserPass ) {


			if (ReturnUserId (UserLogin) == -1) 
				return false;
			
			string passInDatabase = ReturnFieldValue (ReturnUserId (UserLogin), new UserPassField()); 


			PasswordHasher Hasher = new PasswordHasher ();

			if (Hasher.comparePassword(UserPass, passInDatabase))
				return true;


			return false;

		}

		public int ReturnUserPermId( int UserId ) {

			List< string >[] list;

			string query = "SELECT Count(*) FROM users WHERE id=" + UserId.ToString();
			if (db.CountWhere (query) < 1)
				return -1;

			string[] rows = { "perm" };
				
			query = "SELECT * FROM users WHERE id=" + UserId.ToString();
			list = db.Select (query, rows);

			return int.Parse (list [0] [0]);
		}


		public int ReturnUserId( string UserLogin ) {

			List< string >[] list;
			string query = "SELECT Count(*) FROM users WHERE login='" + UserLogin + "'";


			if (db.CountWhere (query) < 1)
				return -1;

			string[] rows = { "id" };
			query = "SELECT * FROM users WHERE login='" + UserLogin + "'";
			list = db.Select (query, rows);

			return int.Parse (list [0] [0]);

		}
			
		public string ReturnFieldValue(int UserId, Fields field)
		{
			if (UserId == -1)
				return null;
			
			List< string >[] list;

			string[] rows = { field.returnDatabaseName() };

			string query = "SELECT * FROM users WHERE id=" + UserId.ToString();

			list = db.Select (query, rows);

			return list [0] [0];

		}


		public bool SetFieldValue(int UserId, Fields field, string value)
		{
			if (UserId == -1)
				return false;

			string query = "UPDATE users SET " + field.returnDatabaseName () + "='" + value + "' WHERE id=" + UserId;


			return db.NonReturnQuery (query);
				

		}


		public void Insert(string query){
			db.NonReturnQuery (query);
		}


	}
}


