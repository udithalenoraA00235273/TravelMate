using TravelMate.Services;
using Xamarin.Forms;

namespace TravelMate
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IPlaceService, PlaceService>();
            Device.SetFlags(new[] { "Shapes_Experimental", "MediaElement_Experimental" });
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
