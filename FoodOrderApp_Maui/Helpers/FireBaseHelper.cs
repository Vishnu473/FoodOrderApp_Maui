using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FoodOrderApp.Utils;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.Helpers
{
    public class FireBaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient(Config.DatabaseUrl);


        private static async Task<List<User>> GetUsers()
        {
            try
            {
                var userList = (await firebase.Child("User").OnceAsync<User>()).Select(item =>
                new User
                {
                    Name = item.Object.Name,
                    Email = item.Object.Email,
                    Mobile = item.Object.Mobile,
                    Address = item.Object.Address,
                    Password = item.Object.Password,
                }).ToList();
                return userList;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }


        public static async Task<User> GetUser(string name)
        {
            try
            {
                var inuser = await GetUsers();
                await firebase.Child("User").OnceAsync<User>();
                var ini = inuser.Where(u => u.Email.Equals(name)).FirstOrDefault();
                return ini;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }

        public static async Task<bool> UpdateUserEmail(string profileName, string emails, string mobileNo, string address, string password, string emailedit)
        {
            try
            {
                var updateEmail = (await firebase.Child("User").OnceAsync<User>()).Where(u => u.Object.Email == emails).FirstOrDefault();
                await firebase.Child("User").Child(updateEmail.Key).PutAsync(new User()
                {
                    Email = emailedit,
                    Password = password,
                    Name = profileName,
                    Address = address,
                    Mobile = mobileNo,
                });
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }

        public static async Task<bool> UpdateUserProfileName(string profname, string usermail, string mobilenoo, string addr, string passwd, string profeditname)
        {
            try
            {
                var toUpdateProfile = (await firebase.Child("User").OnceAsync<User>()).Where(p => p.Object.Email == usermail).FirstOrDefault();
                await firebase.Child("User").Child(toUpdateProfile.Key).PutAsync(new User()
                {
                    Name = profeditname,
                    Mobile = mobilenoo,
                    Email = usermail,
                    Address = addr,
                    Password = passwd
                });
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }
    }
}

