using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Crud.Data.Models.ViewModels;
using Product_Crud.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsService _productService;

        public ProductsController(ProductsService productService)
        {
            _productService = productService;
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct([FromBody]ProductVM product)
        {
             _productService.AddProduct(product);
            return Ok();
        }
        [HttpGet("Get-all-product")]
        public IActionResult GetAllProduct()
        {
            var allProduct = _productService.GetAllProduct();
            return Ok(allProduct);
        }

        [HttpGet("Get-product-by-id/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPut("update-product-by-id/{id}")]
        public IActionResult UpdateProductById(int id, [FromBody]ProductVM product)
        {
            var updateBook = _productService.UpdateProductById(id, product);
            return Ok(updateBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _productService.DeleteBookById(id);
            return Ok();
        }
    }
}
