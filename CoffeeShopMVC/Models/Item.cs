namespace CoffeeShopMVC.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceInCents { get; set; }
        public Order? Order { get; set; }
        //public List<Order> Orders { get; set; } = new List<Order>();

        public string PriceInDollars()
        {
            return string.Format("{0:#.00}", Convert.ToDecimal(PriceInCents) / 100);
        }
    }
}
