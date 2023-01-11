using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodOrderApp.Model;
using FoodOrderApp.Services.Repositories;
using FoodOrderApp.Views;
using SQLite;

namespace FoodOrderApp.ViewModels
{
	public class CartViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		//public ObservableCollection<UserCartItems> CartItemsList { get; set; }
		private ObservableCollection<UserCartItems> _CartItemsList;
		public ObservableCollection<UserCartItems> CartItemsList
        {
			set { _CartItemsList = value; }
			get { return _CartItemsList; }
		}
		SQLiteConnection Database;

		private string _Orders;
		public string Orders
		{
			set { _Orders = value; }
			get { return _Orders; }
		}

		private decimal _totalcartprice;
		public decimal TotalCartPrice
        {
			set { _totalcartprice = value; }
			get { return _totalcartprice; }
		}

		private bool _IsBusy;
		public bool IsBusy
		{
			set { _IsBusy = value; OnPropertyChanged(); }
			get { return _IsBusy; }
		}

        private bool _IsVisible;
        public bool IsVisible
        {
            set { _IsVisible = value; OnPropertyChanged(); }
            get { return _IsVisible; }
        }

        public Command PlaceOrderCommand { get; set; }
        
        public CartViewModel()
		{
            CartItemsList = new ObservableCollection<UserCartItems>();
            LoadItems();
            IsVisible = true;
			PlaceOrderCommand = new Command(async () => await PlaceOrderAsync());
            if(CartItemsList.Count == 0)
			{
				IsVisible = false;
			}
            
        }

        private async Task PlaceOrderAsync()
        {
			IsBusy = true;
			IsVisible = false;
            var id = await new OrderDataService().PlaceOrdersAsync() as string;
			RemoveCartItems();
			await Application.Current.MainPage.Navigation.PushModalAsync(new OrderView(id,TotalCartPrice,Orders));
            IsVisible = true;
            IsBusy = false;
        }

        private void RemoveCartItems()
		{
			var cds = new CartDataService();
			cds.RemoveCartItems();
		}

		private void LoadItems()
        {
			//IsVisible = false;
            Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
			var CartItems = Database.Table<CartItem>().ToList();
			CartItemsList.Clear();
			Orders = "";
            foreach (var item in CartItems)
			{
                CartItemsList.Add(new UserCartItems()
				{
					CartItemId = item.CartItemId,
					FoodId = item.FoodId,
					FoodName = item.FoodName,
					Price = item.Price,
					Quantity = item.Quantity,
					FoodImageUrl = item.ImageUrl,
					TotalCost = item.Price * item.Quantity
				});
				Orders += item.FoodName+"\n";
				TotalCartPrice += (item.Price * item.Quantity);
			}
        }
    }
}

