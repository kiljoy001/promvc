using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShoppe.WebUI.Controllers
{
    public class CPizzaController : Controller
    {
        // GET: Index
        public ActionResult COrder()
        {
            return View();
        }
    }
}