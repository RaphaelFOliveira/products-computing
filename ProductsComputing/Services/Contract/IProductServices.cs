using ProductsComputing.Data.VO;

namespace ProductsComputing.Services.Contract
{
    public interface IProductServices
    {
        public ProductVO Get(int id);
        public List<ProductVO> GetAll();
        public ProductVO Create(ProductVO productVO);
        public ProductVO Update(ProductUpdateVO productVO);
        public void Delete(int id);
    }
}
