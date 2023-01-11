using System;
using Firebase.Database;
using FoodOrderApp.Model;
using FoodOrderApp.Utils;
using System.Linq;
using Firebase.Database.Query;
using FoodOrderApp.Services.Interfaces;

namespace FoodOrderApp.Services.Repositories
{
    public class CategoryDataService : ICategory
    {
        FirebaseClient client;
        public CategoryDataService()
        {
            client = new FirebaseClient(Config.DatabaseUrl);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>()).Select(c => new Category()
                {
                    CategoryId = c.Object.CategoryId,
                    CategoryName = c.Object.CategoryName,
                    ImageUrl = c.Object.ImageUrl
                }).ToList();

            return categories;
        }
    }
}

