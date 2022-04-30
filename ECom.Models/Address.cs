using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
    [Owned]
    public class Address
    {
        public Address(){}
        public Address(string street, string city, string zipcode)
        {
            Street = street;
            City = city;
            ZipCode = zipcode;
        }
        public string Street { get;  set; }
        public string City { get;  set; }
        [DisplayName("Zip Code")]
        public string ZipCode { get;  set; }
    }
}