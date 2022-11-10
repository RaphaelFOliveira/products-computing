namespace ProductsComputing.Data.VO
{
    public class ProductUpdateVO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public StockVO Stock { get; set; }
    }
}
