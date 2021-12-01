using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMate.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLogin : ContentPage
    {
        readonly UserRepo userRepository = new UserRepo();
        public UserLogin()
        {
            InitializeComponent();
        }

        private async void NavigateButtonThree(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserCreation());
        }
        private async void NavigateButtonFour(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FogotPassword());
        }
        private async void BtnUserLogin(object sender, EventArgs e)
        {
            try
            {
                string email_address = email.Text;
                string password_one = password.Text;
                if (String.IsNullOrEmpty(email_address))
                {
                    await DisplayAlert("Warning", "Type your Email Address", "OK");
                }
                if (String.IsNullOrEmpty(password_one))
                {
                    await DisplayAlert("Warning", "Type your Password", "OK");
                }
                string token = await userRepository.SignIn(email_address, password_one);
                if (!string.IsNullOrEmpty(token))
                {
                    await Navigation.PushAsync(new SearchPage());
                }
                else
                {
                    await DisplayAlert("Log In", "Login attempt Failed!", "OK");
                }

            }
            catch(Exception exception)
            {
                if(exception.Message.Contains("INVALID_EMAIL"))
                {
                    await DisplayAlert("Unauthorized", "Email Does Not Exist", "OK");
                }
                else if(exception.Message.Contains("INVALID_PASSWORD"))
                {
                    await DisplayAlert("Unauthorized", "Password Is Incorrect", "OK");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "OK");
                }
            }
            
        }
    }
}