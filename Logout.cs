/*
 * Logout, Mateusz Pater 		
 * 									
 * Klasa służąca do wylogowywania użytkowników
 * 
 */

using System;

namespace Registering
{
	public class Logout
	{

		public User LogoutInit(User user){

			if (!user.returnIsLogged())
				return user;

			user = new User ();

			return user;

		}


	}
}

