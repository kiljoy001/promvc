using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Concrete;

namespace PizzaShoppe.WebUI.HtmlHelper
{
    public struct OrderStruct
    {
        public List<Appetizer> Appetizers;
        public List<Beverage> Beverages;
        public List<Crust> Crusts;
        public List<SpecialtyPizza> Special;
        public List<Topping> Toppings;
    }
}