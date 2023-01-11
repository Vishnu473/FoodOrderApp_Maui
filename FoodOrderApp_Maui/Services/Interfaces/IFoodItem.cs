using System;
using System.Collections.ObjectModel;
using FoodOrderApp.Model;

namespace FoodOrderApp.Services.Interfaces
{
	public interface IFoodItem
	{
		Task<List<FoodItem>> GetFoodItemsAsync();
		Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryId(int id);
        Task<ObservableCollection<FoodItem>> GetFoodItemBySearch(string searchItem);
        Task<ObservableCollection<FoodItem>> GetNewFoodItems();
    }
}

