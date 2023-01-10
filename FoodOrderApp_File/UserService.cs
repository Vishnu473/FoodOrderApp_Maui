using System;
using Firebase.Database;
using Firebase.Database.Query;
using FoodOrderApp.Model;
using Microsoft.Maui.Storage;

namespace FoodOrderApp.Service
{
    public class UserService
    {

        FirebaseClient client;
        public UserService()
        {
            client = new FirebaseClient("https://foodorderapphcl-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> CheckEmail(string email)
        {
            var userEmail = (await client.Child("User").
                OnceAsync<User>()).Where(u => u.Object.Email == email)
                .FirstOrDefault();

            return (userEmail != null);

        }

        public async Task<List<User>> GetAllUser()
        {
            return (await client.Child(nameof(User)).OnceAsync<User>()).Select(f => new User
            {
                Email = f.Object.Email,
                Name = f.Object.Name,
                Mobile = f.Object.Mobile,
                Address = f.Object.Address,
                Password = f.Object.Password,

            }).ToList();

        }

        public async Task AddUser(User users)
        {
            await client.Child("User").PostAsync(users);
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = (await client.Child("User").
                OnceAsync<User>()).Where(u => u.Object.Email == email).Where
               (u => u.Object.Password == password).FirstOrDefault();

            if (user != null)
                return true;
            else
                return false;

        }

    }
}


