using System;

namespace Registering
{
	public class Admin : User
	{
		public Admin (User user) 
		{
			UserInit (user.returnUserId(), user.returnUserLogin(), user.returnUserPass());
			setUserLoginStatusTrue ();
			UserPermId = 1;

		}


	}
}

