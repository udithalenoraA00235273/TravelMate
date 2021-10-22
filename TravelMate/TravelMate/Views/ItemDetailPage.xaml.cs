using System.ComponentModel;
using TravelMate.ViewModels;
using Xamarin.Forms;

namespace TravelMate.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}