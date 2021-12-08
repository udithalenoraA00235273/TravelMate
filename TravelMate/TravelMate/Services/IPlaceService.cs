using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static TravelMate.Models.StationDetailsModel;

namespace TravelMate.Services
{
    public interface IPlaceService
    {
        Task<Place> GetPlace(string Base_url, double latitude, double longitude, string q, int limit, string access_token, string token_type);
         
    }
}
