using System;
using FoodOrderApp.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using FoodOrderApp.Views;
using System.Linq;

namespace FoodOrderApp.ViewModels
{
	public class FoodItemDetailViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		private FoodItem _SelectedFoodItem;
		public FoodItem SelectedFoodItem
        {
			set { _SelectedFoodItem = value; OnPropertyChanged(); }
			get { return _SelectedFoodItem; }
		}

		private int _foodQuantity;
		public int FoodQuantity
        {
			set
			{
				this._foodQuantity = value;
				if (this._foodQuantity < 1)
					this._foodQuantity = 1;
				if (this._foodQuantity >= 6)
					this._foodQuantity = 6;
				OnPropertyChanged();
			}
			get { return _foodQuantity; }
		}

        SQLiteConnection Database;

        public Command DecreaseCommand { get; set; }
        public Command IncreaseCommand { get; set; }
        public Command AddToCartCommand { get; set; }
		public Command ViewMyCartCommand { get; set; }

        public FoodItemDetailViewModel(FoodItem foodItem)
		{
			SelectedFoodItem = foodItem;
			FoodQuantity = 1;
			IncreaseCommand = new Command(() => IncreaseFoodItem());
            DecreaseCommand = new Command(() => DecreaseFoodItem());
            AddToCartCommand = new Command(() => AddToCart());
            ViewMyCartCommand = new Command(async() => await ViewMyCart());

        }

        private void IncreaseFoodItem()
        {
			FoodQuantity++;
        }

        private void DecreaseFoodItem()
        {
			FoodQuantity--;
        }

        private void AddToCart()
        {
            Database = new SQLiteConnection(Constants.DBPath, Constants.flags);
			try
			{
				CartItem ci = new CartItem()
				{
					FoodId = SelectedFoodItem.FoodItemId,
					FoodName = SelectedFoodItem.FoodName,
					Price = SelectedFoodItem.Price,
					Quantity = FoodQuantity,
					ImageUrl = SelectedFoodItem.ImageUrl
				};
				var item = Database.Table<CartItem>()
						   .FirstOrDefault(i => i.FoodId == SelectedFoodItem.FoodItemId);
				if(item == null)
				{
					Database.Insert(ci);
				}
				else{
					item.Quantity += FoodQuantity;
					Database.Update(item);
					Application.Current.MainPage.DisplayAlert("Update", "Quantity Updated", "OK");
				}
				Database.Commit();
				Database.Close();
				Application.Current.MainPage.DisplayAlert("Success", $"Added {SelectedFoodItem.FoodName} to Cart", "OK");
			}
			catch (Exception ex)
			{
				Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
			}
			finally
			{
				Database.Close();
			}
        }

        private async Task ViewMyCart()
        {
			await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }
    }
}

