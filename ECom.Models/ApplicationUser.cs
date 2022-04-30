using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECom.Models;

public class ApplicationUser : IdentityUser<Int32>
{
    /// <summary>
    /// Tên của User
    /// </summary>
    [PersonalData]
    public string? Name { get; set; }
    /// <summary>
    /// Địa chỉ User
    /// </summary>
    [PersonalData]
    public Address? Address { get; set; }
    public List<Basket> Baskets { get; set; }
    public List<Order> Orders { get; set; }
}