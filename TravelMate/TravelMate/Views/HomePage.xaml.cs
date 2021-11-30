using System;
using Xamarin.Forms;

namespace TravelMate.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void NavigateButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        private async void NavigateButtonOne(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserLogin());
        }
    }
}