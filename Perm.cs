using System;

namespace Registering
{
	public class Perm
	{

		static class Perms
		{
			public const int Admin = 1;
			public const int User = 0; 

		}


		public User ReturnObjectWithPerm(User user){

			if (user.returnUserPermId() == Perms.User) {
				return user;
			}
				
			User user_temp = null;

			if (user.returnUserPermId() == Perms.Admin) {
				user_temp = new Admin (user);
			}


			return user_temp;
		}
	}
}

