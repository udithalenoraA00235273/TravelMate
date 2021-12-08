using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelMate.Models;
using static TravelMate.Models.StationDetailsModel;

namespace TravelMate.Services
{
    public class PlaceService : IPlaceService
    {
        public async Task<Place> GetPlace(string Base_url, double lat, double lon, string q, int limit, string accessToken, string tokenType)
        {
            string ll = $"{lat},{lon}";
            string url = Base_url + $"?at={ll}&q={q}&limit={limit}&access_token={accessToken}&token_type={tokenType}";
            HttpClient client= new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Place>(jsonString);
                return result;
            }
            return null;
        }

        public Task<Place> GetPlace(string Base_url, double at, string q, int limit, string access_token, string token_type)
        {
            throw new NotImplementedException();
        }
    }
}
