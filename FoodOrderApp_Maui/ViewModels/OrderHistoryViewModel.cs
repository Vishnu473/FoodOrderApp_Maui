using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using FoodOrderApp.Model;
using FoodOrderApp.Services.Repositories;

namespace FoodOrderApp.ViewModels
{
	public class OrderHistoryViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		public ObservableCollection<OrderHistory> OrderDetails { get; set; }
        public List<OrderHistory> details = new List<OrderHistory>();


		private OrderDetail _FoodName;
		public OrderDetail FoodName
		{
			set { _FoodName = value; OnPropertyChanged(); }
            get { return _FoodName; }
		}
        private OrderDetail _Price;
        public OrderDetail Price
        {
            set { _Price = value; OnPropertyChanged(); }
            get { return _Price; }
        }
        private OrderDetail _OrderDetailId;
        public OrderDetail OrderDetailId
        {
            set { _OrderDetailId = value; OnPropertyChanged(); }
            get { return _OrderDetailId; }
        }
        private OrderDetail _Quantity;
        public OrderDetail Quantity
        {
            set { _Quantity = value; OnPropertyChanged(); }
            get { return _Quantity; }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set { _IsBusy = value; OnPropertyChanged(); }
            get { return _IsBusy; }
        }

        public OrderHistoryViewModel()
		{
            OrderDetails = new ObservableCollection<OrderHistory>();
			GetUserOrders();
		}

		private async void GetUserOrders()
		{
			try
			{
				IsBusy = true;
				OrderDetails.Clear();
                //---from firebase-----
                var service = new OrderHistoryService();
                var details = await service.GetOrderDetailAsync();

                //-----Mock data------
                //var details = GetOrderHistories();

				foreach (var order in details)
				{
					OrderDetails.Add(order);
				}

			}
			catch (Exception ex)
			{
				await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
			}
			finally
			{
				IsBusy = false;
			}
		}

		//public List<OrderHistory> GetOrderHistories()
		//{
		//	details = new List<OrderHistory>()
		//	{
		//		new OrderHistory()
		//		{
		//			OrderId = "123456-fffthr5",
		//			TotalCost = 574,
		//			details = new List<OrderDetail>()
		//			{
		//				new OrderDetail()
		//				{
		//					FoodItemId =1,
		//					FoodName = "Pizza",
		//					OrderDetailId = "234567-fgrt",
		//					Price = 117,
		//					Quantity = 2,
		//					OrderId = "123456-fffthr5"
  //                      },
  //                      new OrderDetail()
  //                      {
  //                          FoodItemId =2,
  //                          FoodName = "Burger",
  //                          OrderDetailId = "f56ghgu6-bmjgjf66",
  //                          Price = 170,
  //                          Quantity = 2,
  //                          OrderId = "123456-fffthr5"
  //                      }
  //                  }
		//		},
  //              new OrderHistory()
  //              {
  //                  OrderId = "fffthr5-123456",
  //                  TotalCost = 340,
  //                  details = new List<OrderDetail>()
  //                  {
  //                      new OrderDetail()
  //                      {
  //                          FoodItemId =2,
  //                          FoodName = "Burger",
  //                          OrderDetailId = "f56ghgu6-bmjgjf66",
  //                          Price = 170,
  //                          Quantity = 2,
  //                          OrderId = "fffthr5-123456-"
  //                      }
  //                  }
  //              },
  //              new OrderHistory()
  //              {
  //                  OrderId = "6gftbvyi7v-787gnhfdr",
  //                  TotalCost = 440,
  //                  details = new List<OrderDetail>()
  //                  {
  //                      new OrderDetail()
  //                      {
  //                          FoodItemId =1,
  //                          FoodName = "Pizza",
  //                          OrderDetailId = "234567-fgrt",
  //                          Price = 120,
  //                          Quantity = 2,
  //                          OrderId = "6gftbvyi7v-787gnhfdr"
  //                      },
  //                      new OrderDetail()
  //                      {
  //                          FoodItemId =3,
  //                          FoodName = "Ice Creams",
  //                          OrderDetailId = "f56ghgu6-bmjgjf66",
  //                          Price = 50,
  //                          Quantity = 2,
  //                          OrderId = "6gftbvyi7v-787gnhfdr"
  //                      },
  //                      new OrderDetail()
  //                      {
  //                          FoodItemId =2,
  //                          FoodName = "Burger",
  //                          OrderDetailId = "6i767ijhhggu6-bmjgjf66",
  //                          Price = 100,
  //                          Quantity = 1,
  //                          OrderId = "6gftbvyi7v-787gnhfdr"
  //                      }
  //                  }
  //              }
  //          };
		//	return details;
		//}

    }
}

