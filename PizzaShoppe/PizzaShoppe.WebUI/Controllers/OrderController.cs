using System.Collections.Generic;
using System.Web.Mvc;
using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.WebUI.Models;

namespace PizzaShoppe.WebUI.Controllers
{
    public class OrderController : Controller
    {
        
        private Entities _context;

        public OrderController(Entities context)
        {
            _context = context;
        }
        
        // GET: Order
        public ActionResult List(Entities context)
        {
            //Create list to pass to the view
            List<MenuItem> MList = new List<MenuItem>();
            //Cycle through the menu items and add them to the list
            foreach (var item in context.MenuItems)
            {
                MList.Add(item);
            }
            MenuItemListViewModel model = new MenuItemListViewModel(MList);
            return View(model);
        }
    }
}