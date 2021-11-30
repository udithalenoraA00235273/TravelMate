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
            string name = userName.Text;
            string email_address = email.Text;
            string password_one = password.Text;
            string password_two = cpassword.Text;

            if (string.IsNullOrEmpty(first_name))
            {
                await DisplayAlert("Warning","First Name Cannot be blank!","OK");
                return;
            }
            if (string.IsNullOrEmpty(last_name))
            {
                await DisplayAlert("Warning", "Last Name Cannot be blank!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(email_address))
            {
                await DisplayAlert ("Warning", "Email Address Cannot be blank!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(password_one))
            {
                await DisplayAlert ("Warning", "Password Cannot be blank!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(password_two))
            {
                await DisplayAlert ("Warning", "Please confirm the Password!", "OK");
                return;
            }
            if (password_one!=password_two)
            {
                await DisplayAlert ("Warning", "Password Not Matching!", "OK");
                return;
            }

            bool isRegistered = await userRepo.Register(name, email_address, password_one);
            if (isRegistered)
            {
                await DisplayAlert("User", "Successfully Registered", "OK");
            }
            else
            {
                await DisplayAlert("User", "Regsitration Unsuccessful", "OK");
            }
        }


    }
}