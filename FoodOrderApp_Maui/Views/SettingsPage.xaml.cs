using FoodOrderApp.Helpers;
using SQLite;

namespace FoodOrderApp.Views;

public partial class SettingsPage : ContentPage
{ 
	public SettingsPage()
	{
		InitializeComponent();
	}

    async void Add_Categories_Clicked(System.Object sender, System.EventArgs e)
    {
        var uploadCategories = new AddCategory();
        await uploadCategories.AddCategoriesAsync();
    }

    async void Add_FoodItems_Clicked(System.Object sender, System.EventArgs e)
    {
        var uploadFoodItems = new AddFoodItem();
        await uploadFoodItems.GetFoodItemsAsync();
    }

    async void Create_Table_Clicked(System.Object sender, System.EventArgs e)
    {
        var table = new CreateCartTable();
        if (table.CreateTableAsync())
        {
            await DisplayAlert("Success", "Created Cart Items Table", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Couldn't create Table", "OK");
        }
    }

}
