using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double  Price { get; set; }
        public string Photo { get; set; }
    }
}
