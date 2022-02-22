using Microsoft.AspNetCore.Mvc;
using ShoppingCart.web.Helper;
using ShoppingCart.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.web.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.product.Price * item.Quantity);
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            var product = new ProductModel();           
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart")==null)
            {
                var cart = new List<Item>();
                cart.Add(new Item {product=product.Find(id),Quantity=1 });
                SessionHelper.SetobjectaAsJson(HttpContext.Session,"cart",cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { product = product.Find(id), Quantity = 1 });
                }
                SessionHelper.SetobjectaAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetobjectaAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
