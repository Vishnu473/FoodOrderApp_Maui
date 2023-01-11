using System;
using FoodOrderApp.Model;
using SQLite;

namespace FoodOrderApp.Services.Repositories
{
	public class CartDataService
	{
        SQLiteConnection Database;
		public int GetCartCount()
		{
            Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
            int result = Database.Table<Model.CartItem>().ToList().Count;
            return result;
        }

        public void RemoveCartItems()
        {
            Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
            Database.DeleteAll<CartItem>();
            Database.Commit();
            Database.Close();
        }
    }
}

