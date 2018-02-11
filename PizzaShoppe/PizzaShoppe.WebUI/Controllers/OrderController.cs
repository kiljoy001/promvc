using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.WebUI.HtmlHelper;
using PizzaShoppe.Domain.Concrete;
using System.Data.Entity;

namespace PizzaShoppe.WebUI.Controllers
{
    public class OrderController : Controller
    {
        //private IAppetizerRepository Appetizers;
        //private IBeverageRepository Beverages;
        //private ICrustRepository Crusts;
        //private ISpecialtyPizzaRepository Special;
        //private IToppingRepository Toppings;
        private OrderStruct data;
        private pizzaEntities _context;

        public OrderController(pizzaEntities context)
        {
            //Debug
            System.Diagnostics.Debug.WriteLine($"Appetizers:{context.Appetizers.Count()} Beverages:{context.Beverages.Count()} Crust:{context.Crusts.Count()} SPizza:{context.SpecialtyPizzas.Count()} Toppings:{context.Toppings.Count()}");
            _context = context;
        }
        ////public OrderController(IAppetizerRepository appetizer, IBeverageRepository beverage, ICrustRepository crust, ISpecialtyPizzaRepository specialty, IToppingRepository custompizzatopping)
        //{
        //    //using (var context = new EFDbContext())
        //    //{
        //    //    this.Appetizers = (IAppetizerRepository)context.Appetizers;
        //    //    this.Beverages = (IBeverageRepository)context.Beverages;
        //    //    this.Crusts = (ICrustRepository)context.Crusts;
        //    //    this.Special = (ISpecialtyPizzaRepository)context.Pizzas;
        //    //    this.Toppings = (IToppingRepository)context.Toppings;
        //    //}
        //    this.Appetizers = appetizer;
        //    this.Beverages = beverage;
        //    this.Crusts = crust;
        //    this.Special = specialty;
        //    this.Toppings = custompizzatopping;
        //}
        // GET: Order
        public ActionResult List(pizzaEntities context)
        {
            data.Appetizers = context.Appetizers.ToList();
            data.Beverages = context.Beverages.ToList();
            data.Crusts = context.Crusts.ToList();
            data.Special = context.SpecialtyPizzas.ToList();
            data.Toppings = context.Toppings.ToList();

            return View(data);
        }
    }
}