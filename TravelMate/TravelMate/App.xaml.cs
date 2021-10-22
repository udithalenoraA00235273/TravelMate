using System;
using TravelMate.Services;
using TravelMate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMate
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
