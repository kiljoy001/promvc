using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.Domain.Entities;
using PizzaShoppe.WebUI.Models;

namespace PizzaShoppe.WebUI.Controllers
{
    public class CartController : Controller
    {
        private pizzaEntities Context;

        public CartController(pizzaEntities context)
        {
            Context = context;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Domain.Concrete.MenuItem item = Context.MenuItems.FirstOrDefault(i => i.ProductID == productId);
            if (item != null)
            {
                GetCart().AddItem(item, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        
        public RedirectToRouteResult RemoveFromCart(int productid, string returnUrl)
        {
            Domain.Concrete.MenuItem item = Context.MenuItems.FirstOrDefault(i => i.ProductID == productid);
            if(item != null)
            {
                GetCart().RemoveLine(item);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}