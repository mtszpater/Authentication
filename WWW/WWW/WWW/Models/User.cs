using System;

namespace Registering
{
	public class User
	{
		
		protected int UserId;
		protected int UserPermId;
		protected bool isLogged;
		protected Fields UserLogin;
		protected Fields UserPass;

		public User() {
			UserId = -1;
			UserLogin = new UserLoginField ();
			UserPass = new UserPassField ();
			UserPermId = -1;
			isLogged = false;
		} 
		public User (int GettingUserId, Fields GettingUserLogin, Fields GettingUserPass) 
		{
			isLogged = false;
			UserPermId = -1;
			UserInit (GettingUserId, GettingUserLogin, GettingUserPass);
		}

		protected void UserInit(int  GettingUserId, Fields GettingUserLogin, Fields GettingUserPass) {
			UserId = GettingUserId;
			UserLogin = GettingUserLogin;
			UserPass = GettingUserPass;
		}

		public override string ToString(){
			return UserId + " " + returnValueOfField(UserLogin) + " " + UserPermId + " " + isLogged.ToString ();
		}

		public int returnUserId() {
			return UserId;
		}
		public Fields returnUserLogin(){
			return UserLogin;
		}
		public Fields returnUserPass(){
			return UserPass;
		}
		public int returnUserPermId(){
			return UserPermId;
		}
		public bool returnIsLogged(){
			return isLogged;
		}
			
		public bool setValueOfField( Fields field, string value )
		{
			return field.setValue (value, UserId);
		}

		public string returnNameOfField( Fields field )
		{
			return field.returnName ();
		}

		public string returnValueOfField( Fields field )
		{
			UserDatabaseController udb = new UserDatabaseController ();
			return udb.ReturnFieldValue (UserId, field);
		}


		public void setUserLoginStatusTrue(){
			UserPermId = 0;
			isLogged = true;
		}
			
		public void setUserPermId(int PermId){
			UserPermId = PermId;
		}

	}
}




