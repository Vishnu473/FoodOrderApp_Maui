using System;
using System.ComponentModel;
using FoodOrderApp.Model;
using System.Runtime.CompilerServices;
using FoodOrderApp.Views;
using FoodOrderApp.Services.Repositories;

namespace FoodOrderApp.ViewModels
{
    public class SignInviewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _Email;
        public string Email
        {
            set
            {
                _Email = value; OnPropertyChanged();
            }
            get { return _Email; }
        }

        private string _Password;
        public string Password
        {
            set
            {
                _Password = value; OnPropertyChanged();
            }
            get { return _Password; }
        }

        public Command LoginCommand { get; }
        public Command SignUpCommand { get; }

        public SignInviewModel()
        {
            LoginCommand = new Command(LoginUser);
            SignUpCommand = new Command(SignUp);
        }

        private async void SignUp(object obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpPage());
        }

        private async void LoginUser()
        {
            string RequiredName = "";
            List<User> userList = await new UserService().GetAllUser();

            foreach (var i in userList)
            {
                if (i.Email == this.Email)
                {
                    RequiredName = i.Name;
                }
            }

            if ((string.IsNullOrEmpty(Email)) || (string.IsNullOrEmpty(Password)))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Field marked with * Cannot be Blank", "Ok");
            }
            else
            {
                var value = new UserService().Login(Email, Password);
                if (await (value) == true)
                {
                    Preferences.Set("Email", Email);
                    Preferences.Set("UserName", RequiredName);

                    await Application.Current.MainPage.DisplayAlert("Success", $"Signed In Successfully as {RequiredName}", "OK");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new HomeView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "Ok");
                }
            }

        }
    }
}

