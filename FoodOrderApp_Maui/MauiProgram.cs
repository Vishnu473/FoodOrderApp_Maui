using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using FoodOrderApp.ViewModels;
using FoodOrderApp.Views;
using FoodOrderApp.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace FoodOrderApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.RegisterAppViews()
			.RegisterAppViewModels()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}


    public static MauiAppBuilder RegisterAppViews(this MauiAppBuilder mauiAppBuilder)
    {
		mauiAppBuilder.Services.AddSingleton<SignInPage>();
        mauiAppBuilder.Services.AddTransient<SignInPage>();
        mauiAppBuilder.Services.AddSingleton<SignUpPage>();
        mauiAppBuilder.Services.AddTransient<SignUpPage>();
        mauiAppBuilder.Services.AddSingleton<HomeView>();
        mauiAppBuilder.Services.AddTransient<HomeView>();
        mauiAppBuilder.Services.AddSingleton<FoodProductView>();
        mauiAppBuilder.Services.AddTransient<FoodProductView>();
        mauiAppBuilder.Services.AddSingleton<FoodItemDetailView>();
        mauiAppBuilder.Services.AddTransient<FoodItemDetailView>();
        mauiAppBuilder.Services.AddSingleton<CartView>();
        mauiAppBuilder.Services.AddTransient<CartView>();
        mauiAppBuilder.Services.AddSingleton<OrderView>();
        mauiAppBuilder.Services.AddTransient<OrderView>();
        mauiAppBuilder.Services.AddSingleton<SearchView>();
        mauiAppBuilder.Services.AddTransient<SearchView>();
        mauiAppBuilder.Services.AddSingleton<SettingsPage>();
        mauiAppBuilder.Services.AddTransient<SettingsPage>();
        mauiAppBuilder.Services.AddSingleton<ProfilePage>();
        mauiAppBuilder.Services.AddTransient<ProfilePage>();
        mauiAppBuilder.Services.AddSingleton<OrderHistoryView>();
        mauiAppBuilder.Services.AddTransient<OrderHistoryView>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterAppViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<SignInviewModel>();
        mauiAppBuilder.Services.AddTransient<SignInviewModel>();
        mauiAppBuilder.Services.AddSingleton<SignUpViewModel>();
        mauiAppBuilder.Services.AddTransient<SignUpViewModel>();
        mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
        mauiAppBuilder.Services.AddTransient<HomeViewModel>();
        mauiAppBuilder.Services.AddSingleton<FoodProductViewModel>();
        mauiAppBuilder.Services.AddTransient<FoodProductViewModel>();
        mauiAppBuilder.Services.AddSingleton<FoodItemDetailViewModel>();
        mauiAppBuilder.Services.AddTransient<FoodItemDetailViewModel>();
        mauiAppBuilder.Services.AddSingleton<CartViewModel>();
        mauiAppBuilder.Services.AddTransient<CartViewModel>();
        mauiAppBuilder.Services.AddSingleton<SearchViewModel>();
        mauiAppBuilder.Services.AddTransient<SearchViewModel>();
        mauiAppBuilder.Services.AddSingleton<ProfileViewModel>();
        mauiAppBuilder.Services.AddTransient<ProfileViewModel>();
        mauiAppBuilder.Services.AddSingleton<OrderHistoryViewModel>();
        mauiAppBuilder.Services.AddTransient<OrderHistoryViewModel>();

        return mauiAppBuilder;
    }
}

