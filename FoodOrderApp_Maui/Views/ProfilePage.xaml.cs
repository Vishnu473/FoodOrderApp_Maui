using FoodOrderApp.Services.Repositories;
namespace FoodOrderApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
	}

    private void ProfileEdit_Clicked(object sender, EventArgs e)
    {
        ProfileEdit.IsVisible = true;
        PEditIcon.IsVisible = false;
        PEditCancelIcon.IsVisible = true;
        saveProfileButton.IsVisible = true;
        ProfileEdit.IsEnabled = true;
        ButtonEmailEdit.IsEnabled = false;
    }

    private void ProfileEditCancel_Clicked(object sender, EventArgs e)
    {
        ProfileEdit.IsVisible = false;
        PEditIcon.IsVisible = true;
        PEditCancelIcon.IsVisible = false;
        saveProfileButton.IsVisible = false;
        ProfileEdit.IsEnabled = false;
        ButtonEmailEdit.IsEnabled = true;
    }

    private void EmailEdit_Clicked(object sender, EventArgs e)
    {
        EmailLabel.IsVisible = false;
        ButtonEmailEdit.IsVisible = false;
        EmailLabelEdit.IsVisible = true;
        ButtonCancelEdit.IsVisible = true;
        saveEmailButton.IsVisible = true;
        EmailLabelEdit.IsEnabled = true;
        PEditIcon.IsEnabled = false;
    }

    private void EmailEditCancel_Clicked(object sender, EventArgs e)
    {
        EmailLabel.IsVisible = true;
        ButtonEmailEdit.IsVisible = true;
        EmailLabelEdit.IsVisible = false;
        ButtonCancelEdit.IsVisible = false;
        saveEmailButton.IsVisible = false;
        EmailLabelEdit.IsEnabled = false;
        PEditIcon.IsEnabled = true;
    }

    async private void Logout_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new HomeView());
        var service = new CartDataService();
        int count = service.GetCartCount();
        if (count > 0)
        {
            var response = await DisplayAlert("Action Needed", $"The cart contains {count} items\nDo you really wanted to logout?","Yes Logout","No Goto cart");
            if (response)
            {
                var cis = new CartDataService();
                cis.RemoveCartItems();
                Preferences.Remove("UserName");
                //Preferences.Clear();
                await Navigation.PushModalAsync(new SignInPage());
            }
            else
            {
                await Navigation.PushModalAsync(new CartView());
            }
        }
        else
        {
            var response = await DisplayAlert("Action Needed", "Do you really wanted to logout?", "Yes", "No");
            if (response)
            {
                var cis = new CartDataService();
                cis.RemoveCartItems();
                Preferences.Remove("UserName");
                //Preferences.Clear();
                await Navigation.PushModalAsync(new SignInPage());
            }
            
        }
    }

    string[] themes = { "Default","Light", "Dark" };

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PickerThemes.ItemsSource = themes;
    }

    void BtnApplyTheme_Clicked(System.Object sender, System.EventArgs e)
    {
        var MergeDictionaries = Application.Current.Resources.MergedDictionaries;
        if(MergeDictionaries != null)
        {
            MergeDictionaries.Clear();
            if (PickerThemes.SelectedItem.ToString().Equals("Dark"))
                MergeDictionaries.Add(new Themes.DarkTheme());
            if(PickerThemes.SelectedItem.ToString().Equals("Default"))
                MergeDictionaries.Add(new Themes.LightTheme1());
            if(PickerThemes.SelectedItem.ToString().Equals("Light"))
                MergeDictionaries.Add(new Themes.LightTheme1());
        }
    }
    async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}
