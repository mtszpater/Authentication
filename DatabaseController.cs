using System;

namespace Registering
{
	public class DatabaseController
	{
		protected Database db;

		protected void Initialize()
		{
			db = Database.Instance;
		}
	}
}

