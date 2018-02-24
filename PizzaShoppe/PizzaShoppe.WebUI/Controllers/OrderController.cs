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
            //Create linked list to pass to the view
            LinkedList<MenuItem> linkedList = new LinkedList<MenuItem>();
            //Cycle through the menu items and add them to the linked list
            foreach(var item in context.MenuItems)
            {
                //Create the node
                LinkedListNode<MenuItem> menuNode = new LinkedListNode<MenuItem>(item);
                //Add the node to the end of the list - linkedList will be in the same order as the context.
                linkedList.AddLast(menuNode);
            }
            return View(linkedList);
        }
    }
}