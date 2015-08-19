namespace CustomerService.Models
{
    public class Purchase
    {
        public Purchase(string productName, double price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName { get; set; }

        public double Price { get; set; }
    }
}
