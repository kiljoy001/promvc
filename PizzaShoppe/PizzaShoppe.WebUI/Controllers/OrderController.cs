using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Entities;
using PizzaShoppe.WebUI.HtmlHelper;

namespace PizzaShoppe.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IAppetizerRepository Appetizers;
        private IBeverageRepository Beverages;
        private ICrustRepository Crusts;
        private ISpecialtyPizzaRepository Special;
        private IToppingRepository Toppings;
        private OrderStruct data;

        public OrderController(IAppetizerRepository appetizer, IBeverageRepository beverage, ICrustRepository crust, ISpecialtyPizzaRepository specialty, IToppingRepository custompizzatopping)
        {
            this.Appetizers = appetizer;
            this.Beverages = beverage;
            this.Crusts = crust;
            this.Special = specialty;
            this.Toppings = custompizzatopping;
        }
        // GET: Order
        public ActionResult List()
        {
            data.Appetizers = Appetizers;
            data.Beverages = Beverages;
            data.Crusts = Crusts;
            data.Special = Special;
            data.Toppings = Toppings;

            return View(data);
        }
    }
}