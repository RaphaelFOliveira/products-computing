using System.Text.Json.Serialization;

namespace ProductsComputing.Data.VO
{
    public class StockVO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public DateTime ProductEntry { get; set; }

        [JsonIgnore]
        public DateTime OutputOfProducts { get; set; }
    }
}
