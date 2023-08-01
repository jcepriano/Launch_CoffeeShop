using System.Reflection.Metadata.Ecma335;

namespace CoffeeShopMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public DateTime DateCreated { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }

    }
}
