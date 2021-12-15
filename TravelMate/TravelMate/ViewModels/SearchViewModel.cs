using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelMate.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using static TravelMate.Models.StationDetailsModel;

namespace TravelMate.ViewModels
{
    public class SearchViewModel: INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
        IPlaceService ips = DependencyService.Get<IPlaceService>();

   
        private ObservableCollection<Item> itemList;

        public ObservableCollection<Item> ItemList
        {
            get
            {
                return itemList;
            }
            set
            {
                itemList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemList"));
            }
        }
       
        public SearchViewModel() 
        {
            getPlace(); 
        }

        string Base_Url = "https://discover.search.hereapi.com/v1/discover";
        string accessToken = "eyJhbGciOiJSUzUxMiIsImN0eSI6IkpXVCIsImlzcyI6IkhFUkUiLCJhaWQiOiJ2dTBHc2NrbHliRlA3MVpGVnNSTCIsImlhdCI6MTYzOTUzNDQ5OCwiZXhwIjoxNjM5NjIwODk4LCJraWQiOiJqMSJ9.ZXlKaGJHY2lPaUprYVhJaUxDSmxibU1pT2lKQk1qVTJRMEpETFVoVE5URXlJbjAuLkZXeTNxb21JQ0xaT1BlWlRUZF8wZ1EuQ3B5ZzFNdnRaTy1va0VHV2ZqMjhEdXZSZTVZd1ZyNmV0TXJwRHppeXYwY2NJNDAtUVlfOVV5d0JKcVFIS3ZPaWJOdGIxZW5RU2F6VjdQZHRvWjVQVGd6LW1remdzeGYwRW1wYWxrcnNUN0xWX2pqQTN4cXc2VEd3enJhMEpBcVN0U1ZHTU1aQ2twSlAwNnRCVEN1Z1h3LjhjanlVMDNDSzdqQ0lBQ0YtUjVYSmhXQU1wS0RfWTRSRjlnM1d2Yk8wa0k.he3ODuHa9G0JucNIEsekM7NSBAEw9D9zTMn1t5CluloS9faDSN8h03-DnyYimd5VjdNfttLXSNwsxjKvuGu1ydkJoftZuANc4sFsbvSeL-Svrnn9jDdmNJB2kBj7DJkqBSeVmCW47YUycXl1kQ8G7RKZdM1JU0rZV3B8a6iyyaFwOf-UNuvsS9wpt-qTyexSHTVgKqWNOplqpqzq2gtyTbaQvCfvpY87tuouLvUM2CCHi_KoVZk1G4NPtAd2NI3LEsdbr9-aaz6__g6FR40-Qlb5A8Tr4jYyDDY8nUfg5QSeaKukoIgHshGFcrctTLt1JkYVX7u4PQ1mEB1OURsAWw";
        string tokenType = "bearer";
        string q = "petrol+station";
        int limit = 5;
        double latitude = 46.49;
        double longitude = -80.99001;



        private async void getPlace()
        {
            {
                var result = await ips.GetPlace(Base_Url, latitude, longitude, q, limit, accessToken, tokenType);
                if(result!=null)
                {
                    ItemList = new ObservableCollection<Item>(result.items);         
                }
            }
           // label = Addresses[0].label;
           // city = Addresses[0].city;
        }
    }
}
