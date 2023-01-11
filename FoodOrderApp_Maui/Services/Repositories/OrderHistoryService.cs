using System;
using Firebase.Database;
using FoodOrderApp.Utils;
using FoodOrderApp.Model;

namespace FoodOrderApp.Services.Repositories
{
	public class OrderHistoryService
	{
		FirebaseClient client;
		public List<OrderHistory> UserOrders;

		public OrderHistoryService()
		{
			client = new FirebaseClient("https://foodorderapphcl-default-rtdb.firebaseio.com/");
			UserOrders = new List<OrderHistory>();
		}

		public async Task<List<OrderHistory>> GetOrderDetailAsync()
		{
			var uname = Preferences.Get("Username","Guest");

			var orders = (await client.Child("Orders")
				.OnceAsync<Order>())
				.Where(o => o.Object.Username.Equals(uname))
				.Select(o => new Order()
				{
					OrderId = o.Object.OrderId,
					TotalPrice = o.Object.TotalPrice
				}).ToList();

			foreach (var order in orders)
			{
				OrderHistory oh = new OrderHistory();
				oh.OrderId = order.OrderId;
				oh.TotalCost = order.TotalPrice;

				var details = (await client.Child("OrderDetails")
					.OnceAsync<OrderDetail>())
					.Where(o => o.Object.OrderId.Equals(order.OrderId))
					.Select(o => new OrderDetail()
					{
						OrderId = o.Object.OrderId,
						OrderDetailId = o.Object.OrderDetailId,
						FoodItemId = o.Object.FoodItemId,
						FoodName = o.Object.FoodName,
						Quantity = o.Object.Quantity,
						Price = o.Object.Price
					}).ToList();
				oh.AddRange(details);
                UserOrders.Add(oh);
			}
			return UserOrders;
		}
	}
}

