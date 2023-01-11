using System;
namespace FoodOrderApp.Model
{
	public class Cart
	{
		public int CartId { get; set; }
		public string User { get; set; }
		public List<CartItem> cartItems { get; set; }
	}
}

