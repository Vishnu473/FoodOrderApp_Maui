using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views;

public partial class OrderView : ContentPage
{
	//OrderViewModel ovm;
	public OrderView(string id,decimal orderPrice,string orderItems)
	{
		InitializeComponent();
		OrderId.Text = id;
		OrderAmount.Text = "Rs. "+orderPrice.ToString();
		OrderItems.Text = orderItems;
	}

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    async void HomeBtn_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushModalAsync(new HomeView());
    }
}
