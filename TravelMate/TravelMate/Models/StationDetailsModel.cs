using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace TravelMate.Models
{
    public class StationDetailsModel
    {
        internal string title;

        public class Address
        {
            public string labels { get; set; }
            public string countryCode { get; set; }
            public string countryName { get; set; }
            public string stateCode { get; set; }
            public string state { get; set; }
            public string county { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string street { get; set; }
            public string postalCode { get; set; }
            public string houseNumber { get; set; }
        }

        public class Position
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Access
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public bool primary { get; set; }
        }

        public class Chain
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Phone
        {
            public string value { get; set; }
            public List<Category> categories { get; set; }
        }

        public class Www
        {
            public string value { get; set; }
            public List<Category> categories { get; set; }
        }

        public class Email
        {
            public string value { get; set; }
        }

        public class Contact
        {
            public List<Phone> phone { get; set; }
            public List<Www> www { get; set; }
            public List<Email> email { get; set; }
        }

        public class Structured
        {
            public string start { get; set; }
            public string duration { get; set; }
            public string recurrence { get; set; }
        }

        public class OpeningHour
        {
            public List<string> text { get; set; }
            public bool isOpen { get; set; }
            public List<Structured> structured { get; set; }
            public List<Category> categories { get; set; }
        }

        public class Supplier
        {
            public string id { get; set; }
        }

        public class Reference
        {
            public Supplier supplier { get; set; }
            public string id { get; set; }
        }

        public class Item
        {
            public string title { get; set; }
            public string id { get; set; }
            public string ontologyId { get; set; }
            public string resultType { get; set; }
            public Address address { get; set; }
            public Position position { get; set; }
            public List<Access> access { get; set; }
            public int distance { get; set; }
            public List<Category> categories { get; set; }
            public List<Chain> chains { get; set; }
            public List<Contact> contacts { get; set; }
            public List<OpeningHour> openingHours { get; set; }
            public List<Reference> references { get; set; }
        }

        public class Response
        {
        }

        public class Place
        {
            public List<Item> items { get; set; }
            public Response response { get; set; }
        }

    }
}
