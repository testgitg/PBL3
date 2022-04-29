using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
    [Owned]
    public class Address
    {
        public Address(){}
        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
        public string Street { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }

        public string Country { get;  set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get;  set; }
    }
}