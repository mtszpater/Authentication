/*
 * Login, Mateusz Pater 		
 * 									
 * Klasa służąca do logowania użytkowników
 * 
 */

using System;

namespace Registering
{
	public class Login
	{

		public User LoginInit(string UserLogin, string UserPass){

			User user;
		
			UserDatabaseController udb = new UserDatabaseController ();

			if (!udb.checkPassCompare(UserLogin, UserPass)) {
				user = new User ();
				return user;
			}


			int DB_UserId = udb.ReturnUserId(UserLogin);
			int DB_UserPermId = udb.ReturnUserPermId(DB_UserId);

			user = new User (DB_UserId, new UserLoginField(), new UserPassField());

			user.setUserLoginStatusTrue ();

			user.setUserPermId(DB_UserPermId);
	
			Perm permMachine = new Perm ();

			user = permMachine.ReturnObjectWithPerm (user);

			return user;


		}

	}
}

