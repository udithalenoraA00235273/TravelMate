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

        private ObservableCollection<Address> addresses;
        public ObservableCollection<Address> Addresses
        {
            get
            {
                return addresses;
            }
            set
            {
                addresses = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public SearchViewModel()
        {
            getPlace(); 
        }

        string Base_Url = "https://discover.search.hereapi.com/v1/discover";
        string accessToken = "eyJhbGciOiJSUzUxMiIsImN0eSI6IkpXVCIsImlzcyI6IkhFUkUiLCJhaWQiOiJ2dTBHc2NrbHliRlA3MVpGVnNSTCIsImlhdCI6MTYzODkyMjM3MiwiZXhwIjoxNjM5MDA4NzcyLCJraWQiOiJqMSJ9.ZXlKaGJHY2lPaUprYVhJaUxDSmxibU1pT2lKQk1qVTJRMEpETFVoVE5URXlJbjAuLmx1djV5dkhJVlV2SEsxY2RxaVZ3RGcuZFkxM2UwYjBfOFNCVFdBeUdVY0N6bTA0SzExWUlVcnFYdW8yRWRvWlU2ZlZCSTZQbTNRb3VmZjdCTlRCXzBWLTEzQ1hOaXhRX3BFNm1lRGxJZG1iMFFpYXFiVzRLV1dRVWlKQU1INUlLbmFNTVFnd1duSzhpTFlkdVhaS3o5SVp5dHdxb1hLb0RHdHRIUlpYaUluYlVnLktDaEc1YTlQMUxuYnhSOURLNFdsNzV4UldUTll1OWlUeHVrNlMwaDJIcFE.davGV7SCQrk0g4JEn82TbRrYEtLPjCVD54iuYSJhuD4SIPR-XeBN-yvClj00UtvbmU0dYzJHjZt7rDik2BolPdlNhCCZ_aHzi_IGHx7ydKZjRTfi07i8qHqboKcGIXX11YhOauUhizMoLKsFJ26LDcCLOtWgqkpvSbis-Ek07jm8CvWc5Q2RqPxcqV4iXTY19MevXaJZhVRcSi2jiJRFztjqv4aZRIGvx1SHvXWJ9WVHwtJpxZ2iUGQxyTI_4hUkIZZm5veh0Rs4FOH9LXE8c-5rhKv9CI1Pnk8gCCJLeS6zFdykorln9YA-tDbAu4vkg94lBdQyqD28vf3dzzxNhQ";
        string tokenType = "bearer";
        string q = "petrol+station";
        int limit = 5;
        

        private async void getPlace()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if(location!=null)
            {
                var result = await ips.GetPlace(Base_Url, location.Latitude, location.Longitude, q, limit, accessToken, tokenType);
                if(result!=null)
                {
                    Addresses = result.response.addresses;
                }
            }       
        }
    }
}
