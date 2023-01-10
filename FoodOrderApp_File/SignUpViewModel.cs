using System;
using System.ComponentModel;
using FoodOrderApp.Service;
using FoodOrderApp.View;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using FoodOrderApp.Model;
using CommunityToolkit.Maui.Alerts;

namespace FoodOrderApp.ViewModel
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _Name;
        public string Name
        {
            set
            {
                _Name = value; OnPropertyChanged();
            }
            get { return _Name; }
        }

        private string _Mobile;
        public string Mobile
        {
            set
            {
                _Mobile = value; OnPropertyChanged();
            }
            get { return _Mobile; }
        }

        private string _Address;
        public string Address
        {
            set
            {
                _Address = value; OnPropertyChanged();
            }
            get { return _Address; }
        }

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


        public Command RegisterCommand { get; }
        public Command SignInCommand { get; }

        public SignUpViewModel()
        {
            RegisterCommand = new Command(RegisterUser);
            SignInCommand = new Command(SignIn);
        }

        private async void SignIn(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignInView());
        }

        private async void RegisterUser()
        {
            var valiate = "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$";
            var validatePass = "(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$";

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Mobile) || string.IsNullOrEmpty(Address)
                || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Field marked with * Cannot Be Blank", "Ok");
            }

            else if (!String.IsNullOrWhiteSpace(Email) && !(Regex.IsMatch(Email, valiate)))
            {
                var toast = Toast.Make("Invalid Email Id", CommunityToolkit.Maui.Core.ToastDuration.Long, 30);
                toast.Show();
            }
            else if (!String.IsNullOrWhiteSpace(Password) && !(Regex.IsMatch(Password, validatePass)))
            {
                var toast = Toast.Make("Invalid Password", CommunityToolkit.Maui.Core.ToastDuration.Long, 30);
                toast.Show();
            }

            else
            {

                var GetUserEmail = new UserService().CheckEmail(Email);

                if (await (GetUserEmail) == true)
                {
                    var toast = Toast.Make("Email Id Already Registered", CommunityToolkit.Maui.Core.ToastDuration.Long, 25);
                    toast.Show();
                }
                else
                {
                    var user = new User()
                    {
                        Name = this.Name,
                        Mobile = this.Mobile,
                        Address = this.Address,
                        Email = this.Email,
                        Password = this.Password
                    };

                    await new UserService().AddUser(user);

                    await Application.Current.MainPage.DisplayAlert("Success", "Registered Successfully", "Ok");

                }
            }

        }

    }
}


