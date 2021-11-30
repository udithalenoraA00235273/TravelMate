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
    public partial class UserCreation : ContentPage
    {
        UserRepo userRepo = new UserRepo();
        public UserCreation()
        {
            InitializeComponent();
        }

        private async void User_Registered(object sender, EventArgs e)
        {
            try
            {
                string name = userName.Text;
                string email_address = email.Text;
                string password_one = password.Text;
                string password_two = cpassword.Text;

                if (string.IsNullOrEmpty(name))
                {
                    await DisplayAlert("Warning", "First Name Cannot be blank!", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(email_address))
                {
                    await DisplayAlert("Warning", "Email Address Cannot be blank!", "OK");
                    return;
                }
                if (password_one.Length<6)
                {
                    await DisplayAlert("Warning", "Password must contain at least 6 characters!", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(password_one))
                {
                    await DisplayAlert("Warning", "Password Cannot be blank!", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(password_two))
                {
                    await DisplayAlert("Warning", "Please confirm the Password!", "OK");
                    return;
                }
                if (password_one != password_two)
                {
                    await DisplayAlert("Warning", "Password Not Matching!", "OK");
                    return;
                }

                bool isRegistered = await userRepo.Register(email_address, password_one, name);
                if (isRegistered)
                {
                    await DisplayAlert("User", "Successfully Registered", "OK");
                    await Navigation.PopModalAsync();
                }
                else
                {
                    await DisplayAlert("User", "Regsitration Unsuccessful", "OK");
                }
            }
            catch(Exception exception)
            {
                if(exception.Message.Contains("EMAIL_EXISTS"))
                {
                   await DisplayAlert("Warning", "Email Address Already Exists!", "OK");
                }
                else
                {
                    await DisplayAlert("Error", exception.Message, "OK");
                }
            }         

        }
    }
}