using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelMate.Models
{
    public class UserRepo
    {
        static string webAPIKey = "AIzaSyAaHWl9yVnTYd9oYqhn1NKtpfplQfH84d4";
        FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));

        public async Task<bool> Register(string name, string email_address, string password_one)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(name, email_address, password_one);
            if(!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }

    }
}
