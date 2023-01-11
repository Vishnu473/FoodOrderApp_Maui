using System;
using FoodOrderApp.Model;
using FoodOrderApp.Services.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FoodOrderApp.Views;
using System.Runtime.CompilerServices;

namespace FoodOrderApp.ViewModels
{
	public class HomeViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		public ObservableCollection<Category> CategoriesList { get; set; }
		public ObservableCollection<FoodItem> FoodList { get; set; }

		private int _CartCount;
		public int CartCount
		{
			set { _CartCount = value; OnPropertyChanged(); }
			get { return _CartCount; }
		}

		private string _SearchItem;
		public string SearchItem
		{
			set { _SearchItem = value; OnPropertyChanged(); }
			get { return _SearchItem; }
		}
		//public Command AddToCartCommand { get; set; }
        public Command SearchCommand { get; set; }
		public HomeViewModel()
		{
			CategoriesList = new ObservableCollection<Category>();
			FoodList = new ObservableCollection<FoodItem>();
            
			GetCategories();
			GetNewItems();
			CartCount = new CartDataService().GetCartCount();
			SearchCommand = new Command(async () => await SearchViewAsync());
			//AddToCartCommand = new Command();
        }

        private async Task SearchViewAsync()
        {
			if (String.IsNullOrEmpty(SearchItem))
				await Application.Current.MainPage.DisplayAlert("Error", "Enter FoodItem to search", "Ok");
			else
			{
				await Application.Current.MainPage.Navigation.PushModalAsync(new SearchView(SearchItem));
				//SearchItem = String.Empty;
            }
        }

        private async void GetNewItems()
        {
			var data = await new FoodItemDataService().GetNewFoodItems();
			FoodList.Clear();
			foreach (var item in data)
			{
				FoodList.Add(item);
			}
        }

        private async void GetCategories()
        {
			var data = await new CategoryDataService().GetCategoriesAsync();
			CategoriesList.Clear();
			foreach (var item in data)
			{
				CategoriesList.Add(item);
			}
        }
    }
}

