using ProductsComputing.Data.Converter.Contract;
using ProductsComputing.Data.VO;
using ProductsComputing.Model;
using ProductsComputing.Repository.Contract;
using ProductsComputing.Services.Contract;

namespace ProductsComputing.Services.Implementation
{
    public class ProductServices : IProductServices
    {
        private readonly IConvertProduct<Product, ProductVO> _convertProductVO;
        private readonly IConvertProduct<ProductVO, Product> _convertProduct;
        private readonly IConvertProduct<Product, ProductUpdateVO> _convertProductUpdateVO;
        private readonly IRepositoryGeneric<Product> _repository;

        public ProductServices(IConvertProduct<Product, ProductVO> convertProductVO, IConvertProduct<ProductVO, Product> convertProduct, IConvertProduct<Product, ProductUpdateVO> convertProductUpdateVO, IRepositoryGeneric<Product> repository)
        {
            _convertProductVO = convertProductVO;
            _convertProduct = convertProduct;
            _convertProductUpdateVO = convertProductUpdateVO;
            _repository = repository;
        }

        public ProductVO Create(ProductVO productVO)
        {
            if (String.IsNullOrEmpty(productVO.Brand) || String.IsNullOrEmpty(productVO.Model) || productVO.Price < 100)
                return null;

            Product product = _convertProductVO.Converter(productVO);

            product = _repository.Create(product);

            return _convertProduct.Converter(product);
        }

        public void Delete(int id)
        {
            if (id > 0)
                _repository.Delete(id);
        }

        public ProductVO Get(int id)
        {
            if (id <= 0)
                return null;

           return _convertProduct.Converter(_repository.Get(id));
        }

        public List<ProductVO> GetAll()
        {
           return _repository.GetAll(new Product())
                .Select(x => _convertProduct.Converter(x))
                .ToList();
        }

        public ProductVO Update(ProductUpdateVO productUpdateVO)
        {
            if (productUpdateVO.Id <= 0)
                return null;

            Product product = _convertProductUpdateVO.Converter(productUpdateVO);

            return _convertProduct.Converter(_repository.Update(product));
        }
    }
}
