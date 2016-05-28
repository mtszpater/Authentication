using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Registering
{
	public sealed class Database
	{
		private static Database instance;
		MySqlConnection conn;
		string myConnectionString;


		static class DatabaseConfig
		{
			public const string DBName = "project";
			public const string DBPass = ""; 
			public const string DBHost = "localhost";
			public const string DBUser = "root";

		}

		private Database() {
			Initialize ();
		}

		public static Database Instance
		{
			get 
			{
				if (instance == null)
				{
					instance = new Database();
				}
				return instance;
			}
		}



		private void Initialize(){ 
			
			myConnectionString = "" +
				"server="		+DatabaseConfig.DBHost+		";" +
				"uid="			+DatabaseConfig.DBUser+		";" +
				"pwd="			+DatabaseConfig.DBPass+		";" +
				"database="		+DatabaseConfig.DBName+		";"	;
			
			conn = new MySqlConnection(myConnectionString);

		}


		private bool OpenConnection(){
			
			try
			{
				conn.Open();
				return true;
			}
			catch (MySqlException ex)
			{

				switch (ex.Number)
				{
				case 0:
					MessageBox.Show("Cannot connect to server.  Contact administrator");
					break;
				case 1045:
					MessageBox.Show("Invalid username/password, please try again");
					break;
				}

				System.Environment.Exit(1);
				return false;
			}

		}
			
		private bool CloseConnection()
		{
			try
			{
				conn.Close();
				return true;
			}
			catch (MySqlException ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}
			
		public bool NonReturnQuery(string query)
		{

			if (this.OpenConnection() == true)
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);

				cmd.ExecuteNonQuery();

				this.CloseConnection();
			}
			return false;

		}
			
		public int CountWhere(string query)
		{

			int Count = -1;

			if (this.OpenConnection() == true)
			{
				MySqlCommand cmd = new MySqlCommand(query, conn);

				Count = int.Parse(cmd.ExecuteScalar()+"");

				this.CloseConnection();

				return Count;
			}
			else
			{
				return Count;
			}
		}

		public List< string >[] Select(string query, string[] rows)
		{
			if (this.OpenConnection() == true)
			{
				List< string >[] list = new List< string >[rows.Length];

				for (int i = 0; i < rows.Length; ++i) {
					list [i] = new List< string > ();
				}

				MySqlCommand cmd = new MySqlCommand(query, conn);

				MySqlDataReader dataReader = cmd.ExecuteReader();

				while (dataReader.Read())
				{
					for (int i = 0; i < rows.Length; ++i) {
						list [i].Add(dataReader[rows[i]] + "");
					}
				}
					
				dataReader.Close();

				this.CloseConnection();

				return list;
			}
			else
			{
				return null;
			}
		}
			
	}
}



