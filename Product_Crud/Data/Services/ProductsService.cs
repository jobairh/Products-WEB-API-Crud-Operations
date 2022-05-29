using Microsoft.EntityFrameworkCore;
using Product_Crud.Data.Models;
using Product_Crud.Data.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Data.Services
{
    public class ProductsService
    {
        public AppDbContext _context;
        public ProductsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProduct(ProductVM product)
        {
            var _product = new Product()
            {
                ItemName = product.ItemName,
                Description = product.Description,
                Price = product.Price,
                ProductMade = product.ProductMade,
                DateRead = DateTime.Now
            };
            _context.Products.Add(_product);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var allProduct = await _context.Products.ToListAsync();
            return allProduct;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(n => n.Id == productId);
            
        }

        public async Task<Product> UpdateProductById(int productId, ProductVM product)
        {
            var updateProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == productId);
             if(updateProduct != null)
            {
                updateProduct.ItemName = product.ItemName;
                updateProduct.Description = product.Description;
                updateProduct.Price = product.Price;
                updateProduct.ProductMade = product.ProductMade;
                updateProduct.DateRead = DateTime.Now;

                await _context.SaveChangesAsync();
            }
            return updateProduct;
        }

        public async Task DeleteBookById(int ProductId)
        {
            var _product = await _context.Products.FirstOrDefaultAsync(n => n.Id == ProductId);
            if(_product != null)
            {
                _context.Products.Remove(_product);
                await _context.SaveChangesAsync();
            }
            

        }
    }
}
