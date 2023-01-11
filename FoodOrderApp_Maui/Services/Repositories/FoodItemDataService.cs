using System;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Utils;
using FoodOrderApp.Services.Interfaces;
using FoodOrderApp.Model;
using System.Collections.ObjectModel;

namespace FoodOrderApp.Services.Repositories
{
	public class FoodItemDataService : IFoodItem
	{
		FirebaseClient client;
		public FoodItemDataService()
		{
			client = new FirebaseClient(Config.DatabaseUrl);
		}


        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
			var foodItems = (await client.Child("FoodItems")
				.OnceAsync<FoodItem>()).Select(f => new FoodItem()
				{
					FoodItemId = f.Object.FoodItemId,
					CategoryId = f.Object.CategoryId,
					FoodName = f.Object.FoodName,
					Description = f.Object.Description,
					ImageUrl = f.Object.ImageUrl,
					Price = f.Object.Price
				}).ToList();
			return foodItems;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryId(int id)
        {
			var foodItemsByCategory = new ObservableCollection<FoodItem>();
			var products = (await GetFoodItemsAsync()).Where(p => p.CategoryId == id).ToList();
			foreach (var item in products)
			{
				foodItemsByCategory.Add(item);
			}

			return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemBySearch(string searchItem)
        {
			var foodItemsBySearch = new ObservableCollection<FoodItem>();
			var searchResult = (await GetFoodItemsAsync())
				.Where(s => s.FoodName.ToUpper().Contains(searchItem.ToUpper()) |
				 s.Description.ToUpper().Contains(searchItem.ToUpper())).ToList();
			foreach (var item in searchResult)
			{
				foodItemsBySearch.Add(item);
			}

			return foodItemsBySearch;
        }

        public async Task<ObservableCollection<FoodItem>> GetNewFoodItems()
        {
			var newFoodItems = new ObservableCollection<FoodItem>();
			var items = (await GetFoodItemsAsync()).OrderByDescending(i => i.FoodItemId).Take(7).ToList();
			foreach (var item in items)
			{
				newFoodItems.Add(item);
			}

			return newFoodItems;
        }
    }
}

