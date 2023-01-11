using System;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using FoodOrderApp.Utils;

namespace FoodOrderApp.Helpers
{
	public class AddCategory
	{
		public List<Category> Categories { get; set; }

        FirebaseClient Client;

		public AddCategory()
		{
            Client = new FirebaseClient(Config.DatabaseUrl);

            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Veg Pizza",
                    ImageUrl = "https://www.dominos.co.in/theme2/front/images/menu-images/my-vegpizza.webp"
                },
                new Category()
                {
                    CategoryId=2,
                    CategoryName="Non Veg Pizza",
                    ImageUrl="https://www.dominos.co.in/files/items/Pepper_Barbeque_&_Onion.jpg"
                },
                new Category()
                {
                    CategoryId=3,
                    CategoryName="Pizza Mania",
                    ImageUrl="https://www.dominos.co.in/theme2/front/images/menu-images/my-pizzamania.webp"
                },
                new Category()
                {
                    CategoryId=4,
                    CategoryName="MealsnCombo",
                    ImageUrl="https://www.dominos.co.in/blog/wp-content/uploads/2019/11/meal_4_1_gb_combo_veg.jpg"
                },
                new Category()
                {
                    CategoryId=5,
                    CategoryName="Sides",
                    ImageUrl="https://www.dominos.co.in/files/items/Main_Menu-VG.jpg"
                },
                new Category()
                {
                    CategoryId=6,
                    CategoryName="Desserts",
                    ImageUrl="https://www.dominos.co.in/files/items/CAKE03.jpg"
                }
            };
		}

        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach(var category in Categories)
                {
                    await Client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        ImageUrl = category.ImageUrl
                    });
                }
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error",e.Message,"OK");
            }
        }
	}
}

