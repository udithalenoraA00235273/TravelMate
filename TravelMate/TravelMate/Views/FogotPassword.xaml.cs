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
    public partial class FogotPassword : ContentPage
    {
        UserRepo userRepository = new UserRepo();
        public FogotPassword()
        {
            InitializeComponent();
        }

        private async void BtnSendLink(object sender, EventArgs e)
        {
            string email_address = email.Text;
            if(string.IsNullOrEmpty(email_address))
            {
                await DisplayAlert("Warning", "Please enter the email", "OK");
                return;
            }

            bool isSend = await userRepository.ResetPassword(email_address);
            if(isSend)
            {
                await DisplayAlert("Information", "Send the email to reset password", "OK");
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Information", "Link sending failed", "OK");
            }

        }
    }
}