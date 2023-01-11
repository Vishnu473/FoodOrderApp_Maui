using FoodOrderApp.ViewModels;
using FoodOrderApp.Model;
namespace FoodOrderApp.Views;

public partial class SearchView : ContentPage
{
	SearchViewModel svm;
	public SearchView(string searchWord)
	{
		InitializeComponent();
		svm = new SearchViewModel(searchWord);
        this.BindingContext = svm;
    }

    async void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
		var selectedProduct = e.CurrentSelection.FirstOrDefault() as FoodItem;
		if (selectedProduct == null)
			return;
		await Navigation.PushModalAsync(new FoodItemDetailView(selectedProduct));
		((CollectionView)sender).SelectedItem = null;
    }
    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
