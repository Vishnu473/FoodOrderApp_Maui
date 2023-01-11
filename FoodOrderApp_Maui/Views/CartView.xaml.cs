namespace FoodOrderApp.Views;

public partial class CartView : ContentPage
{
	public CartView()
	{
		InitializeComponent();
		LoadItems();
	}

    private void LoadItems()
    {
        var cis = new Services.Repositories.CartDataService();
        var count = cis.GetCartCount();
        var info = "No Items in Cart";
        if (count == 0)
        {
            Info.Text = info;
            Info.IsVisible = true;
        }
        else
        {
            Info.IsVisible = false;
        }
    }

    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}
