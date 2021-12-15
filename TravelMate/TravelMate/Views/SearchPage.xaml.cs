using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TravelMate.Models.StationDetailsModel;

namespace TravelMate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
           /* test.ItemsSource = new List<Item>()
            {
                new Item{title = "test1", resultType = "test2"}
            };*/
        }
    }
}