using AXA_TEST_CASE.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepo _productRepo;

        public ProductController(ProductRepo productRepo)
        {
            this._productRepo = productRepo;
        }

        [HttpGet("getAllProducts")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
           var result = await _productRepo.GetAllProduct();

            if (result == null)
                return BadRequest("No Data Found ");

            return Ok(result.ToList());

        }

        [HttpGet("getProduct")]
        public async Task<ActionResult<Product>> GetProduct(string Id)
        {
            var result = await _productRepo.GetProduct(int.Parse(Id));

            if (result == null)
                return BadRequest("No Data Found ");

            return result;

        }

        [HttpPost("insertProduct")]
        public async Task<ActionResult> InsertProduct(ProductRequest request)
        {
            var result = await _productRepo.InsertProduct(request);

            if (!result)
                return BadRequest("Insert Product Failed ");

            return Ok("Insert Product Succeed");

        }

        [HttpPost("updateProduct")]
        public async Task<ActionResult> UpdateProduct(ProductRequest request)
        {
            var result = await _productRepo.UpdateProduct(request);

            if (!result)
                return BadRequest("Update Product Failed ");

            return Ok("Update Product Succeed");

        }
    }
}
