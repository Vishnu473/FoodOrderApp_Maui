using FoodOrderApp.Model;
using FoodOrderApp.ViewModels;
namespace FoodOrderApp.Views;

public partial class FoodProductView : ContentPage
{
	FoodProductViewModel fpm;
	public FoodProductView(Category category)
	{
		InitializeComponent();
		fpm = new FoodProductViewModel(category);
		this.BindingContext = fpm;
	}

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopModalAsync();
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
