using System;
using SQLite;
namespace FoodOrderApp.Model
{
	[Table("CartItem")]
	public class CartItem
	{
		[AutoIncrement, PrimaryKey]
		public int CartItemId { get; set; }
		public int FoodId { get; set; }
		public string FoodName { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
	}
}

