using System;
namespace FoodOrderApp.Model
{
	public class Order
	{
		public string OrderId { get; set; }
		public string Username { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime DateTime { get; set; }
	}
}

