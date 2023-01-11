using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodOrderApp.Model;
using FoodOrderApp.Services.Repositories;
using FoodOrderApp.Views;

namespace FoodOrderApp.ViewModels
{
	public class FoodProductViewModel : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set { _SelectedCategory = value; OnPropertyChanged(); }
            get { return _SelectedCategory; }
        }
        
        private ObservableCollection<FoodItem> _FoodItems;
        public ObservableCollection<FoodItem> FoodItems
        {
            set { _FoodItems = value; }
            get { return _FoodItems; }
        }

        //public ObservableCollection<FoodItem> FoodItems { get; set; }
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
        public FoodProductViewModel(Category category)
        {
            SelectedCategory = category;
            FoodItems = new ObservableCollection<FoodItem>();
            GetFoodItems(category.CategoryId);
        }

        private async void GetFoodItems(int categoryId)
        {
            var data = await new FoodItemDataService().GetFoodItemsByCategoryId(categoryId);
            FoodItems.Clear();
            foreach (var item in data)
            {
                FoodItems.Add(item);
            }
        }
    }
}

