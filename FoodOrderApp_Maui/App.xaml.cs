using FoodOrderApp.Views;
namespace FoodOrderApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new SettingsPage());
		if (Preferences.ContainsKey("UserName"))
		{
			MainPage = new NavigationPage(new HomeView());
        }
		else
		{
            MainPage = new NavigationPage(new SignInPage());
        }
    }
}

