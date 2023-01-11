using FoodOrderApp.Helpers;
using FoodOrderApp.Model;
using FoodOrderApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name =
            null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Command SaveProfile_Command { get; set; }
        public Command SaveEmail_Command { get; set; }

        public Command Address_Command { get; set; }

        public Command ProfileEditCancelButton { get; set; }

        public Command EmailEditCancelButton { get; set; }


        public ProfileViewModel()
        {
            //users = new ObservableCollection<User>();
            GetUsersFrom();
            SaveProfile_Command = new Command(() => UpdateProfile(ProfileName, Email, MobileNo, Address, Password, ProfileNameEdit));
            SaveEmail_Command = new Command(() => UpdateEmail(ProfileName, Email, MobileNo, Address, Password, EmailEdit));
            //Address_Command = new Command(() => AddressViewPage(Address));
            ProfileEditCancelButton = new Command(() => ProfileEditClicked(ProfileName));
            EmailEditCancelButton = new Command(() => EmailEditCancelClicked(Email));
        }

        private void EmailEditCancelClicked(string emailss)
        {
            EmailEdit = emailss;
        }

        private void ProfileEditClicked(string namess)
        {
            ProfileNameEdit = namess;
        }

        private async void UpdateEmail(string profileName, string emails, string mobileNo, string address, string password, string emailedit)
        {
            var email = await FireBaseHelper.UpdateUserEmail(profileName, emails, mobileNo, address, password, emailedit);
            if (email)
            {
                await Application.Current.MainPage.DisplayAlert("Success", " Email Successfully Updated", "Ok");
                Email = EmailEdit;
            }
        }

        private async void UpdateProfile(string profname, string usermail, string mobilenoo, string addr, string passwd, string profeditname)
        {
            var profile = await FireBaseHelper.UpdateUserProfileName(profname, usermail, mobilenoo, addr, passwd, profeditname);
            if (profile)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Successfully Updated", "Ok");
                ProfileName = ProfileNameEdit;
            }
        }

        
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _emailEdit;
        public string EmailEdit
        {
            get
            {
                return _emailEdit;
            }
            set
            {
                _emailEdit = value;
                OnPropertyChanged(nameof(EmailEdit));
            }
        }

        private string _profileEdit;
        public string ProfileNameEdit
        {
            get
            {
                return _profileEdit;
            }
            set
            {
                _profileEdit = value;
                OnPropertyChanged(nameof(ProfileNameEdit));
            }
        }

        private string _profIcon;
        public string ProfID
        {
            get { return _profIcon; }
            set { _profIcon = value; OnPropertyChanged(nameof(ProfID)); }
        }

        private string _name;
        public string ProfileName
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(ProfileName));
            }
        }

        private string _mobile;
        public string MobileNo
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
                OnPropertyChanged(nameof(MobileNo));
            }
        }
        
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public async void GetUsersFrom()
        {
            //users.Clear();
            var key = Preferences.Get("Email", "Guest");
            var userDetails = await FireBaseHelper.GetUser(key);
            MobileNo = userDetails.Mobile;
            ProfileName = userDetails.Name;
            Email = userDetails.Email;
            Address = userDetails.Address;
            Password = userDetails.Password;
            ProfID = userDetails.Name.Substring(0, 1).ToUpper();
        }

       


    }
}

