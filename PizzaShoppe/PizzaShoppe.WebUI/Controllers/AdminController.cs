using System.Collections.Generic;
using System.Web.Mvc;
using PizzaShoppe.Domain.Concrete;

namespace PizzaShoppe.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private Entities Context;
        public AdminController(Entities context)
        {
            Context = context;
        }

        public ViewResult Index()
        {
            //Create list to pass to the view
            List<MenuItem> MList = new List<MenuItem>();
            //Cycle through the menu items and add them to the list
            foreach (var item in Context.MenuItems)
            {
                MList.Add(item);
            }
            return View(MList);
        }
    }
}