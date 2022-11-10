using ProductsComputing.Data.Converter.Contract;
using ProductsComputing.Data.VO;
using ProductsComputing.Model;

namespace ProductsComputing.Data.Converter.Implementation
{
    public class ConvertProduct : IConvertProduct<Product, ProductVO>, IConvertProduct<ProductVO, Product>, IConvertProduct<Product, ProductUpdateVO>
    {
        public Product Converter(ProductVO origin)
        {
            if (origin == null) 
                return null;

            Stock stock = new Stock
            {
                Id = origin.Stock.Id,
                OutputOfProducts = origin.Stock.OutputOfProducts,
                ProductEntry = origin.Stock.ProductEntry,
                Quantity = origin.Stock.Quantity
            };

            return new Product
            {
                Brand = origin.Brand,
                Id = origin.Id,
                Model = origin.Model,
                Price = origin.Price,
                Stock = stock
            };
        }

        public ProductVO Converter(Product origin)
        {
            if (origin == null)
                return null;

            StockVO stock = new StockVO
            {
                Id = origin.Stock.Id,
                OutputOfProducts = origin.Stock.OutputOfProducts,
                ProductEntry = origin.Stock.ProductEntry,
                Quantity = origin.Stock.Quantity
            };

            return new ProductVO
            {
                Brand = origin.Brand,
                Id = origin.Id,
                Model = origin.Model,
                Price = origin.Price,
                Stock = stock
            };
        }

        public Product Converter(ProductUpdateVO origin)
        {
            if (origin == null)
                return null;

            Stock stock = new Stock
            {
                Id = origin.Stock.Id,
                OutputOfProducts = origin.Stock.OutputOfProducts,
                ProductEntry = origin.Stock.ProductEntry,
                Quantity = origin.Stock.Quantity
            };

            return new Product
            {
                Brand = origin.Brand,
                Id = origin.Id,
                Model = origin.Model,
                Price = origin.Price,
                Stock = stock
            };
        }
    }
}
