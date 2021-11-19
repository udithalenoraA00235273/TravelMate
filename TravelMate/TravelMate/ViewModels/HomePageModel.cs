using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TravelMate.ViewModels
{
    public class HomePageModel : BaseViewModel
    {
        public HomePageModel()
        {
            Title = "HOME PAGE";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}