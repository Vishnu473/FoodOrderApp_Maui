using System;
namespace FoodOrderApp.Model
{
	public class UserCartItems
	{
		public int CartItemId { get; set; }
		public int FoodId { get; set; }
		public string FoodName { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public decimal TotalCost { get; set; }
		public string FoodImageUrl { get; set; }
	}
}

