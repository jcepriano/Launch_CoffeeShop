namespace CoffeeShopMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public double OrderTotal()
        {
            double total = 0D;
            foreach(var order in Orders)
            {
                total += order.ItemTotal();
            }
            return total;
        }

        public List<Item> ItemList()
        {
            var itemList = new List<Item>();
            foreach(var order in Orders)
            {
                itemList.AddRange(order.Items);
            }
            return itemList;
        }
    }
}
