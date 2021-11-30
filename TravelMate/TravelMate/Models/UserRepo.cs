﻿using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TravelMate.Models
{
    public class UserRepo
    {
        string webAPIKey = "AIzaSyAaHWl9yVnTYd9oYqhn1NKtpfplQfH84d4";
        FirebaseAuthProvider authProvider;

        public UserRepo()
        {
             authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIKey));
        }
        public async Task<bool> Register(string email_address, string password_one, string name)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email_address, password_one, name);
            if(!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }

        public async Task<string> SignIn(string email_address, string password_one)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email_address, password_one);
            if(!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }

    }
}
