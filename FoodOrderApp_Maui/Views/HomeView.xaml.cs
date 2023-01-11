using FoodOrderApp.Model;
namespace FoodOrderApp.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
	}

    async void CV_Categories_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var category = e.CurrentSelection.FirstOrDefault() as Category;
        if (category == null)
        {
            return;
        }
        await Navigation.PushModalAsync(new FoodProductView(category));
        ((CollectionView)sender).SelectedItem = null;
    }

    async void CartImage_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new CartView());
    }
    
    //async void OrderHistory_Clicked(System.Object sender, System.EventArgs e)
    //{
    //    await Navigation.PushAsync(new OrderHistoryPage());
    //}

    async void UserProfile_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new ProfilePage());
    }

    async void CV_FoodItemList_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        var foodItem = e.CurrentSelection.FirstOrDefault() as FoodItem;
        if (foodItem == null)
        {
            return;
        }
        await Navigation.PushModalAsync(new FoodItemDetailView(foodItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}
