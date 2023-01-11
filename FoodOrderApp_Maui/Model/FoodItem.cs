using System;
namespace FoodOrderApp.Model
{
	public class FoodItem
	{
		public int FoodItemId { get; set; }
		public string FoodName { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public int CategoryId { get; set; }
		public int Price { get; set; }
	}
}

