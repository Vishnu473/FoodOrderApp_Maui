using System;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using FoodOrderApp.Utils;

namespace FoodOrderApp.Helpers
{
	public class AddFoodItem
	{
        FirebaseClient Client;

        public List<FoodItem> FoodItems { get; set; }

		public AddFoodItem()
		{
            Client = new FirebaseClient(Config.DatabaseUrl);

            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    FoodItemId = 27,
                    CategoryId = 1,
                    FoodName = "Farmhouse",
                    Description ="Delightful combination of onion, capsicum, tomato & grilled mushroom - Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/farmhouse.png",
                    Price=459
                },
                new FoodItem()
                {
                    FoodItemId = 2,
                    CategoryId = 1,
                    FoodName = "Margherita",
                    Description ="A hugely popular margherita, with a deliciously tangy single cheese topping - Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_margherita_2502.jpg",
                    Price=239

                },
                new FoodItem()
                {
                    FoodItemId = 1,
                    CategoryId = 1,
                    FoodName = "Peppy Paneer",
                    Description ="Chunky paneer with crisp capsicum and spicy red pepper - quite a mouthful! - Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_peppy_paneer.jpg",
                    Price=459

                },
                new FoodItem()
                {
                    FoodItemId = 26,
                    CategoryId = 1,
                    FoodName = "Mexican Green Wave",
                    Description ="A pizza loaded with crunchy onions, crisp capsicum, juicy tomatoes and jalapeno with a liberal sprinkling of exotic Mexican herbs  - Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_mexican_green_wave.jpg",
                    Price=329

                },
                new FoodItem()
                {
                    FoodItemId = 3,
                    CategoryId = 2,
                    FoodName = "Chicken Dominator",
                    Description ="Treat your taste buds with Double Pepper Barbecue Chicken, Peri-Peri Chicken, Chicken Tikka & Grilled Chicken Rashers - Non Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_chicken_dominator.jpg",
                    Price=599
                },
                new FoodItem()
                {
                    FoodItemId = 17,
                    CategoryId = 2,
                    FoodName = "Chicken Golden Delight",
                    Description ="Mmm! Barbeque chicken with a topping of golden corn loaded with extra cheese. Worth its weight in gold! - Non Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_chicken_golden_delight.jpg",
                    Price=559
                },
                new FoodItem()
                {
                    FoodItemId = 18,
                    CategoryId = 2,
                    FoodName = "Indo Fusion Chicken Pizza",
                    Description ="Relish the fusion of 5 of your favorite chicken toppings - Peri Peri Chicken, Chicken Pepperoni, Chicken Tikka - Non Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/cheesepepperoni.png",
                    Price=699
                },
                new FoodItem()
                {
                    FoodItemId = 23,
                    CategoryId = 2,
                    FoodName = "Non Veg Supreme",
                    Description ="Bite into supreme delight of Black Olives, Onions, Grilled Mushrooms, Pepper BBQ Chicken, Peri-Peri Chicken, Grilled Chicken Rashers - Non Veg Pizza",
                    ImageUrl ="https://images.dominos.co.in/new_non_veg_supreme.jpg",
                    Price=599
                },
                new FoodItem()
                {
                    FoodItemId = 4,
                    CategoryId = 3,
                    FoodName = "Veg Loaded",
                    Description ="Tomato | Grilled Mushroom |Jalapeno |Golden Corn | Beans in a fresh pan crust - Pizza Mania",
                    ImageUrl ="https://images.dominos.co.in/pizza_mania_veg_loaded.png",
                    Price=159
                },
                new FoodItem()
                {
                    FoodItemId = 5,
                    CategoryId = 3,
                    FoodName = "Chicken Sausage",
                    Description ="American classic! Spicy, herbed chicken sausage on pizza - Pizza Mania",
                    ImageUrl ="https://images.dominos.co.in/pizza_mania_chicken_sausage.png",
                    Price=109
                },
                new FoodItem()
                {
                    FoodItemId = 22,
                    CategoryId = 3,
                    FoodName = "Golden Corn",
                    Description ="Golden Corn - Sweet Corn Pizza - Pizza Mania",
                    ImageUrl ="https://images.dominos.co.in/pizza_mania_golden_corn.png",
                    Price=89
                },
                new FoodItem()
                {
                    FoodItemId = 21,
                    CategoryId = 3,
                    FoodName = "Non Veg Loaded",
                    Description ="Peri - Peri chicken | Pepper Barbecue | Chicken Sausage in a fresh pan crust - Pizza Mania",
                    ImageUrl ="https://images.dominos.co.in/pizza_mania_non-veg_loaded.png",
                    Price=169
                },
                new FoodItem()
                {
                    FoodItemId = 6,
                    FoodName="Meal for 2: Moroccan Pasta Pizza & Achari Do Pyaza",
                    CategoryId =4,
                    Description="Regular Moroccan Pasta Pizza Veg + Regular Achari do Pyaza + Garlic Bread + Pepsi",
                    ImageUrl="https://images.dominos.co.in/CMB1391.jpg",
                    Price=339
                },
                new FoodItem()
                {
                    FoodItemId =19 ,
                    FoodName="Meal for 2: Pepper BBQ Chicken & Chicken Dominator",
                    CategoryId =4,
                    Description="Regular Pepper BBQ Chicken Pizza + Regular Chicken Dominator + Garlic Bread + Pepsi",
                    ImageUrl="https://images.dominos.co.in/CMB1386.jpg",
                    Price=619
                },
                new FoodItem()
                {
                    FoodItemId = 7,
                    FoodName="Meal for 4: Non Veg Extravaganza & Chicken Dominator",
                    CategoryId =4,
                    Description="Medium Non Veg Extravaganza Pizza + Medium Chicken Dominator + Garlic Bread + 2 Pepsi",
                    ImageUrl="https://images.dominos.co.in/CMB1411.jpg",
                    Price=919
                },
                new FoodItem()
                {
                    FoodItemId = 25,
                    FoodName="Meal for 4: Feast Veg Extravanga & Indo Tandoori Paneer",
                    CategoryId =4,
                    Description="Medium Feast Veg Extravanga Pizza + Medium Indi Tandoori Paneer + Garlic Bread + 2 Pepsi",
                    ImageUrl="https://images.dominos.co.in/CMB1403.jpg",
                    Price=1059
                },
                new FoodItem()
                {
                    FoodItemId =8 ,
                    FoodName="Garlic BreadSticks",
                    CategoryId = 5,
                    Description="The endearing tang of garlic in breadstics baked to perfection.",
                    ImageUrl="https://images.dominos.co.in/Garlic_bread.png",
                    Price=109
                },
                new FoodItem()
                {
                    FoodItemId =9 ,
                    FoodName="Paneer Tikka Stuffed Garlic Bread",
                    CategoryId = 5,
                    Description="Freshly Baked Stuffed Garlic Bread with Cheese, Onion and Paneer Tikka fillings. Comes with a dash of Basil Parsley Sprinkle",
                    ImageUrl="https://images.dominos.co.in/BRD0030.png",
                    Price=169
                },
                new FoodItem()
                {
                    FoodItemId = 24,
                    FoodName="Taco Mexican Non Veg",
                    CategoryId = 5,
                    Description="A crispy flaky wrap filled with Hot and Smoky Chicken Patty rolled over a creamy Harissa Sauce.",
                    ImageUrl="https://images.dominos.co.in/Taco_Nvg.png",
                    Price=169
                },
                new FoodItem()
                {
                    FoodItemId = 10,
                    FoodName="Basic Pesto  Dip",
                    CategoryId = 5,
                    Description="Your perfect pizza partner! Savour your pizza slices with this new rich, herby & salty dip with the goodness of basil leaves",
                    ImageUrl="https://images.dominos.co.in/DIP0013.jpg",
                    Price=49
                },
                new FoodItem()
                {
                    FoodItemId = 11,
                    FoodName="Harissa Dip",
                    CategoryId = 5,
                    Description="A spicy & peppery pizza dip which can help you add the right amount of spiciness to your favorite pizza slices",
                    ImageUrl="https://images.dominos.co.in/DIP0014.jpg",
                    Price=49
                },
                new FoodItem()
                {
                    FoodItemId= 12,
                    CategoryId= 5,
                    FoodName="ChefBoss Oregano (50g)",
                    Description="Your favourite oregano seasoning now in a bottle",
                    ImageUrl="https://images.dominos.co.in/SID0116_19d.jpg",
                    Price=110
                },
                new FoodItem()
                {
                    FoodItemId= 13,
                    CategoryId= 5,
                    FoodName="ChefBoss Chilli Flakes (45g)",
                    Description="Fiery chilli flakes topping in a bottle",
                    ImageUrl="https://images.dominos.co.in/SID0115_19d.jpg",
                    Price=85
                },
                new FoodItem()
                {
                    FoodItemId=14,
                    CategoryId=6,
                    FoodName="Red Velvet Lava Cake",
                    Description="A truly indulgent experience with sweet and rich red velvet cake on a creamy cheese flavoured base to give a burst of flavour in every bite!",
                    ImageUrl="https://images.dominos.co.in/CAKE03.jpg",
                    Price=139
                },
                new FoodItem()
                {
                    FoodItemId=21,
                    CategoryId=6,
                    FoodName="Choco Lava Cake",
                    Description="Chocolate lovers delight! Indulgent, gooey molten lava inside chocolate cake",
                    ImageUrl="https://images.dominos.co.in/Choco_Lava.png",
                    Price=109
                },
                new FoodItem()
                {
                    FoodItemId=16,
                    CategoryId=6,
                    FoodName="ButterScotch Mousse cake",
                    Description="A Creamy & Chocolaty indulgence with layers of rich, fluffy Butterscotch Cream and delicious Dark Chocolate Cake, topped with crunchy Dark Chocolate morsels - for a perfect dessert treat!",
                    ImageUrl="https://images.dominos.co.in/Butterscotch.png",
                    Price=109
                },
                new FoodItem()
                {
                    FoodItemId=15,
                    CategoryId=6,
                    FoodName="Brownie Fantasy",
                    Description="Sweet Temptation! Hot Chocolate Brownie drizzled with chocolate fudge sauce",
                    ImageUrl="https://images.dominos.co.in/Brownie_Fantasy.png",
                    Price=79
                }
            };
		}

        public async Task GetFoodItemsAsync()
        {
            try
            {
                foreach (var fooditem in FoodItems)
                {
                    await Client.Child("FoodItems").PostAsync(new FoodItem(){
                        CategoryId = fooditem.CategoryId,
                        FoodItemId =fooditem.FoodItemId,
                        FoodName = fooditem.FoodName,
                        Description = fooditem.Description,
                        ImageUrl = fooditem.ImageUrl,
                        Price = fooditem.Price
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message,"OK");
            }
        }
	}
}

