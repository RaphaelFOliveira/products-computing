namespace ProductsComputing.Model
{
    public class Product : BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public Stock Stock { get; set; }

        public Product()
        {
        }

        public Product(string brand, string model, double price, Stock stock)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Stock = stock;
        }
    }
}
