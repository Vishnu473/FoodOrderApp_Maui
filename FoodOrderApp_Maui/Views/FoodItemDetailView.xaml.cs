using FoodOrderApp.Model;
using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views;

public partial class FoodItemDetailView : ContentPage
{
	FoodItemDetailViewModel fdvm;
	public FoodItemDetailView(FoodItem foodItem)
	{
		InitializeComponent();
		fdvm = new FoodItemDetailViewModel(foodItem);
		this.BindingContext = fdvm;
	}

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}
