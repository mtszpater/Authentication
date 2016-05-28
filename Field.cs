using System;

namespace Registering
{
	public class Fields
	{
		protected string name;
		protected string databaseName;

		public Fields (){
			name = null;
			databaseName = null;
		}

		public Fields(string Gname, string GdbName){
			name = Gname;
			databaseName = GdbName;
		}

		public string returnName() {
			return name;
		}
			
		public string returnDatabaseName() { 
			return databaseName;
		}

		virtual public bool validation ( string gValue ) {
			return true;
		}

		virtual public bool setValue( string gValue, int UserId ) {

			if (!validation (gValue))
				return false;

			UserDatabaseController udb = new UserDatabaseController ();

			udb.SetFieldValue (UserId, this, gValue); 

			return true;
		}

	}
}
