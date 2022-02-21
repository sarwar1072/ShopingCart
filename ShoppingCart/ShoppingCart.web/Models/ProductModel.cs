using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.web.Models
{
    public class ProductModel
    {
        public List<Product> listOfProduct { get; set; }

        public List<Product> GetProducts()
        {
            listOfProduct = new List<Product> { new Product()
            {
                       Id=1,Name="rose",Price=1.23,Photo="Faluda.jpg"
            },
            new Product()
            {
                       Id=2,Name="rose2",Price=1.23,Photo="non-vegPizza.jpg"
            },
            new Product()
            {
                       Id=3,Name="rose3",Price=1.23,Photo="S-VegPizza.jpg"
            },
            new Product()
            {
                       Id=4,Name="ros4e",Price=1.23,Photo="vegPizza.jpg"
            }

             };
            return listOfProduct;
        }

        public Product Find(int id)
        {
            List<Product> product = GetProducts();
            var prod = product.Where(a => a.Id == id).FirstOrDefault();
            return prod;
        }
    }
}
