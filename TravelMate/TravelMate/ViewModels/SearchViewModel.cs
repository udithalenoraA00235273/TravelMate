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
        string accessToken = "eyJhbGciOiJSUzUxMiIsImN0eSI6IkpXVCIsImlzcyI6IkhFUkUiLCJhaWQiOiJ2dTBHc2NrbHliRlA3MVpGVnNSTCIsImlhdCI6MTYzOTY1OTYwNCwiZXhwIjoxNjM5NzQ2MDA0LCJraWQiOiJqMSJ9.ZXlKaGJHY2lPaUprYVhJaUxDSmxibU1pT2lKQk1qVTJRMEpETFVoVE5URXlJbjAuLnd2Y3JfTXpNcUtINjBfcmluRzJaUFEuR2Vuc1M0VUZWRGxIUzBuTnBrNWY3RTNTakZEdXh2bVRpUFNCRE93bGEyOHZSVDlXdktwRGpOMEUxQTVqMzljV05qdVN1Qlh2eHFmTVItb0JJTW5SaUg4cGsyVlF1NW41eE1TZkg0cXdfTXd6a2Zld2dnRTdkeHNaRlU5aFhDdlNNTUUtenpIWTRSRlBlR3AwZHJ6RnFRLndabGU2SlZiZDcwTFBvdWZSTE5qd3ZpdEVfOFNlRl9NSUsyVndtdEVBZkE.qzFz3PBMFLpZgkBT0RUuQnhAH4_i8JB6fW7GP7hJ7OFSerkZy78Wz0fDyOWEtQOxk5Mb4iSDj3D2EqC-jqpxgN7MLWQNFt_BN0zxE-ZlXDtYIVs5n0kmmk74shPP0svTRmOO8hkDrsdxeNyOd3d_218_f8R3ptbfFcj8B0cXam9rcLLR5WGV0RdxtJnKZHclEbDhkpPobkSX8e3wRzOjQfnhulqnn8NRfxLp6_i60PQXsi9hZRc3BAK9OU2rNiS9r6_J6BtLWjdqh9slP56hI80zNXY6LYmFNTCd8oTUH1Xk7W2SExz1y1HKhvrFYLBGMvUDvGEfjKOb2GHi6UGdeA";
        string tokenType = "bearer";
        string q = "petrol+station";
        int limit = 5;
        double latitude = 43.837208;
        double longitude = -79.508278;



        private async void getPlace()
        {
            {
                var result = await ips.GetPlace(Base_Url, latitude, longitude, q, limit, accessToken, tokenType);
                if(result!=null)
                {
                    result.items.ForEach(x => {
                        if(x.contacts != null && x.contacts.Count > 0)
                        {
                            x.phoneNumber = x.contacts[0].phone[0].value;
                        }
                    });
                    result.items.ForEach(c => {
                        if (c.openingHours != null && c.openingHours.Count > 0)
                        {
                            c.openingTime = c.openingHours[0].text[0];
                        }
                    });
                    ItemList = new ObservableCollection<Item>(result.items);         
                }
            }
           // label = Addresses[0].label;
           // city = Addresses[0].city;
        }
    }
}
