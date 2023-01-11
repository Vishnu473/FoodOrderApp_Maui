using System;
using FoodOrderApp.Model;
using Firebase.Database;
using SQLite;
using FoodOrderApp.Utils;
using Firebase.Database.Query;

namespace FoodOrderApp.Services.Repositories
{
	public class OrderDataService
	{
		FirebaseClient client;
		SQLiteConnection Database; 
		public OrderDataService()
		{
			client = new FirebaseClient(Config.DatabaseUrl);
		}

		public async Task<string> PlaceOrdersAsync()
		{
            Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
			var orderedItems = Database.Table<CartItem>().ToList();

			var orderId = Guid.NewGuid().ToString();
			var username = Preferences.Get("UserName", "Guest");

			decimal TotalOrderPrice = 0;
			foreach (var item in orderedItems)
			{
				OrderDetail od = new OrderDetail()
				{
					OrderId = orderId,
					OrderDetailId = Guid.NewGuid().ToString(),
					FoodItemId = item.FoodId,
					FoodName = item.FoodName,
					Price = item.Price,
					Quantity = item.Quantity
				};
				TotalOrderPrice += item.Quantity * item.Price;
				await client.Child("OrderDetails").PostAsync(od);
			}

			await client.Child("Orders").PostAsync(
				new Order()
				{
					OrderId = orderId,
					Username = username,
					TotalPrice = TotalOrderPrice,
					DateTime = DateTime.Now
				});
			return orderId;
			
		}
	}
}

