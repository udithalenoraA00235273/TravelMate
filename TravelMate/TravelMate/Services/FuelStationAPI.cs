
using System;
using System.Collections.Generic;
using System.Text;


namespace TravelMate.Services
{
    public class FuelPrice
    {
        public double price { get; set; }
        public string fuelType { get; set; }
        public string unit { get; set; }
        public string currency { get; set; }
        public DateTime lastUpdateTimestamp { get; set; }
    }

    public class Period
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class RegularOpeningHour
    {
        public int daymask { get; set; }
        public List<Period> period { get; set; }
    }

    public class OpeningHours
    {
        public List<RegularOpeningHour> regularOpeningHours { get; set; }
    }

    public class StationDetails
    {
        public OpeningHours openingHours { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public string postalCode { get; set; }
    }

    public class Position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class FuelStation
    {
        public string brand { get; set; }
        public string brandIcon { get; set; }
        public List<FuelPrice> fuelPrice { get; set; }
        public StationDetails stationDetails { get; set; }
        public Address address { get; set; }
        public Position position { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public DateTime lastUpdateTimestamp { get; set; }
        public string timeZone { get; set; }
    }

    public class FuelStations
    {
        public List<FuelStation> fuelStation { get; set; }
    }

    public class Root
    {
        public bool hasMore { get; set; }
        public FuelStations fuelStations { get; set; }
    }

}
