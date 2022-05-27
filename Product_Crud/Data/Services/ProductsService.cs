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

        public void AddProduct(ProductVM product)
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
            _context.SaveChanges();
        }
        public List<Product> GetAllProduct()
        {
            var allProduct = _context.Products.ToList();
            return allProduct;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(n => n.Id == productId);
            
        }

        public Product UpdateProductById(int productId, ProductVM product)
        {
            var updateProduct = _context.Products.FirstOrDefault(n => n.Id == productId);
             if(updateProduct != null)
            {
                updateProduct.ItemName = product.ItemName;
                updateProduct.Description = product.Description;
                updateProduct.Price = product.Price;
                updateProduct.ProductMade = product.ProductMade;
                updateProduct.DateRead = DateTime.Now;

                _context.SaveChanges();
            }
            return updateProduct;
        }

        public void DeleteBookById(int ProductId)
        {
            var _product = _context.Products.FirstOrDefault(n => n.Id == ProductId);
            if(_product != null)
            {
                _context.Products.Remove(_product);
                _context.SaveChanges();
            }
            

        }
    }
}
