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
        public async Task<IActionResult> AddProduct([FromBody]ProductVM product)
        {
            await _productService.AddProduct(product);
            return Ok();
        }
        [HttpGet("Get-all-product")]
        public async Task<IActionResult> GetAllProduct()
        {
            var allProduct = await _productService.GetAllProduct();
            return Ok(allProduct);
        }

        [HttpGet("Get-product-by-id/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPut("update-product-by-id/{id}")]
        public async Task<IActionResult> UpdateProductById(int id, [FromBody]ProductVM product)
        {
            var updateBook = await _productService.UpdateProductById(id, product);
            return Ok(updateBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            await _productService.DeleteBookById(id);
            return Ok();
        }
    }
}
