using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ECom.Models
{
    /// <summary>
    /// Model này k tạo bảng mà chuyển thành các cột trong các bảng khác có nó
    /// </summary>
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