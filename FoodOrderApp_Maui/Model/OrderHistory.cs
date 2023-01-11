using System;
namespace FoodOrderApp.Model
{
	public class OrderHistory : List<OrderDetail>
	{
		public string OrderId { get; set; }
		public string Username { get; set; }
		public decimal TotalCost { get; set; }
		//public List<OrderDetail> details { get; set; }
        public DateTime DateTime { get; set; }
    }
}

