using System;
namespace FoodOrderApp.Model
{
	public class OrderDetail
	{
		public string OrderDetailId { get; set; }
		public string OrderId { get; set; }
		public int FoodItemId { get; set; }
		public string FoodName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	} 
}


