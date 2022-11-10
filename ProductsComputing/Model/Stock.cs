namespace ProductsComputing.Model
{
    public class Stock : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime ProductEntry { get; set; }
        public DateTime OutputOfProducts { get; set; }

        public Stock()
        {
        }

        public Stock(int id, int quantity, DateTime productEntry, DateTime outputOfProducts)
        {
            Id = id;
            Quantity = quantity;
            ProductEntry = productEntry;
            OutputOfProducts = outputOfProducts;
        }
    }
}
