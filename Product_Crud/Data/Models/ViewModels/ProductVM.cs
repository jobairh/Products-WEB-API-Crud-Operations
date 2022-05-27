using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Crud.Data.Models.ViewModels
{
    public class ProductVM
    {
        public string ItemName { get; set; }

        public string Description { get; set; }
        public int Price { get; set; }
        public string ProductMade { get; set; }
        public DateTime DateRead { get; set; }
    }
}
