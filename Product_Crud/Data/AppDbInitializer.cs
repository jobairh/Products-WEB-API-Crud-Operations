using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Product_Crud.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Product()
                    {
                        ItemName = "Laptop",
                        Description = "Acer E5-575-51NJ",
                        Price = 30000,
                        ProductMade = "China",
                        DateRead = DateTime.Now
                    },
                    new Product()
                    {
                        ItemName = "Mobile",
                        Description = "Redmi Note-7",
                        Price = 20000,
                        ProductMade = "India",
                        DateRead = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
