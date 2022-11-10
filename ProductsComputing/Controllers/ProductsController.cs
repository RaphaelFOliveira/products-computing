using Microsoft.AspNetCore.Mvc;
using ProductsComputing.Data.VO;
using ProductsComputing.Services.Contract;

namespace ProductsComputing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("/product")]
        public IActionResult Create([FromBody] ProductVO productVO)
        {
            productVO = _productServices.Create(productVO);

            if (productVO == null)
                return Problem("All attributes need to be filled", statusCode: 400);

            return Created("/product", productVO.Id);
        }

        [HttpDelete("/product/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productServices.Delete(id);

            return NoContent();
        }

        [HttpGet("/product/{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            ProductVO productVO = _productServices.Get(id);

            if (productVO is null)
                return Problem("Is product not found", statusCode: 404);

            return Ok(productVO);
        }

        [HttpGet("/product")]
        public IActionResult GetAll()
        {
            return Ok(_productServices.GetAll());
        }

        [HttpPut("/product")]
        public IActionResult Update([FromBody] ProductUpdateVO productUpdateVO)
        {
            ProductVO productVO = _productServices.Update(productUpdateVO);

            if (productVO is null)
                return Problem("Product not found", statusCode: 400);

            return Ok(productVO);
        }
    }
}