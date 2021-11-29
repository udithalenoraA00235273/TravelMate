using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLogin : ContentPage
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private async void NavigateButtonThree(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserCreation());
        }
    }
}