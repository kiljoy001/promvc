using System.Collections.Generic;
using System.Web.Mvc;
using PizzaShoppe.Domain.Concrete;


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
            //Create list to pass to the view
            List<MenuItem> MList = new List<MenuItem>();
            //Cycle through the menu items and add them to the list
            foreach (var item in context.MenuItems)
            {
                MList.Add(item);
            }
            return View(MList);
        }
    }
}