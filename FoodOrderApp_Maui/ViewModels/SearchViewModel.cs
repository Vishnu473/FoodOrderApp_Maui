using System;
using System.Collections.ObjectModel;
using FoodOrderApp.Model;
using System.ComponentModel;
using FoodOrderApp.Services.Repositories;
using System.Runtime.CompilerServices;

namespace FoodOrderApp.ViewModels
{
	public class SearchViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged([CallerMemberName] string name = null) =>
		  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		public ObservableCollection<FoodItem> SearchFoodItems { get; set; }

        private FoodItem _Description;
        public FoodItem Description
        {
            set { _Description = value; OnPropertyChanged(); }
            get { return _Description; }
        }
        private FoodItem _FoodName;
        public FoodItem FoodName
        {
            set { _FoodName = value; OnPropertyChanged(); }
            get { return _FoodName; }
        }
        private FoodItem _ImageUrl;
        public FoodItem ImageUrl
        {
            set { _ImageUrl = value; OnPropertyChanged(); }
            get { return _ImageUrl; }
        }
        private FoodItem _Price;
        public FoodItem Price
        {
            set { _Price = value; OnPropertyChanged(); }
            get { return _Price; }
        }

        private string _searchText;
        public string searchText
        {
            set { _searchText = value; OnPropertyChanged(); }
            get { return _searchText; }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set { _IsBusy = value; OnPropertyChanged(); }
            get { return _IsBusy; }
        }

        private bool _IsWait;
        public bool IsWait
        {
            set { _IsWait = value; OnPropertyChanged(); }
            get { return _IsWait; }
        }

        public SearchViewModel(string SearchWord)
		{
			SearchFoodItems = new ObservableCollection<FoodItem>();
            this.searchText = SearchWord;
			GetFoodItemsBySearch(SearchWord);
		}

        private async void GetFoodItemsBySearch(string searchWord)
        {
            try
            {
                IsWait = false;
                IsBusy = true;
                var data = await new FoodItemDataService().GetFoodItemBySearch(searchWord);
                SearchFoodItems.Clear();
                foreach (var item in data)
                {
                    SearchFoodItems.Add(item);
                }
                IsBusy = false;
                IsWait = true;
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}

