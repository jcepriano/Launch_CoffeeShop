using CoffeeShopMVC.Controllers;
using System.Reflection.Metadata.Ecma335;

namespace CoffeeShopMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer Customer { get; set; }

        public double ItemTotal()
        {
            double total = 0d;
            foreach (var item in Items)
            {
                total += item.PriceInCents;
            }
            return total;
        }
    }
}
