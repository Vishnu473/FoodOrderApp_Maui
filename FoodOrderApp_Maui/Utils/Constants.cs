using System;
namespace FoodOrderApp
{
	public static class Constants
	{
		public const string DBFileName = "MyDB.db3";
		public static string DBPath => Path.Combine(FileSystem.AppDataDirectory, DBFileName);
		public const SQLite.SQLiteOpenFlags flags = //Open DB in Read-write Mode
													SQLite.SQLiteOpenFlags.ReadWrite |
													//Create DB if not exist
													SQLite.SQLiteOpenFlags.Create |
													//To enable Multi-threading DB access
													SQLite.SQLiteOpenFlags.SharedCache;
	}
}

