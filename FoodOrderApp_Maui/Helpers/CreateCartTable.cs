using System;
using FoodOrderApp.Model;
using SQLite;

namespace FoodOrderApp.Helpers
{
	public class CreateCartTable
	{
		SQLiteConnection Database;

		
		public  bool CreateTableAsync()
		{
			try
			{
                Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
                var result = Database.CreateTable<CartItem>();
                return true;
			}
			catch (Exception ex)
			{
                return false;
            }
		}
	}
}

