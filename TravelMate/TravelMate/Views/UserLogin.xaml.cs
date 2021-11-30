using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMate.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLogin : ContentPage
    {
        UserRepo userRepository = new UserRepo();
        public UserLogin()
        {
            InitializeComponent();
        }

        private async void NavigateButtonThree(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserCreation());
        }

        private async void BtnUserLogin(object sender, EventArgs e)
        {
            string email_address = email.Text;
            string password_one = password.Text;
            string token = await userRepository.SignIn(email_address, password_one);
            if(!string.IsNullOrEmpty(token))
            {
               await Navigation.PushAsync(new SearchPage());
            }
            else
            {
                await DisplayAlert("Log In", "Login attempt Failed!", "OK");
            }
        }
    }
}