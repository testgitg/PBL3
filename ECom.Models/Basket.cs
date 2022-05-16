using System.ComponentModel.DataAnnotations;

namespace ECom.Models
{
    public class Basket
    {
        [Key]
        public int Id {get; set;}
        public int BuyerId {get; set;}
        public ApplicationUser Buyer { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
    
}