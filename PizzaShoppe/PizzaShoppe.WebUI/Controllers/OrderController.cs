using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShoppe.Domain.Concrete;
using System.Data.Entity;


namespace PizzaShoppe.WebUI.Controllers
{
    public class OrderController : Controller
    {
        
        private pizzaEntities _context;

        public OrderController(pizzaEntities context)
        {
            _context = context;
        }
        
        // GET: Order
        public ActionResult List(pizzaEntities context)
        {
            return View(context);
        }
    }
}