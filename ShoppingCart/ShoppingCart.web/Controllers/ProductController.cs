using Microsoft.AspNetCore.Mvc;
using ShoppingCart.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.web.Controllers
{
    [Route("Product")]

    public class ProductController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            var model = new ProductModel();
            ViewBag.product = model.GetProducts();
            return View();
        }
    }
}
