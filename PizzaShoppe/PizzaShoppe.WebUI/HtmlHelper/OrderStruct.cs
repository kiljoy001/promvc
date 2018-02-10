using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Entities;

namespace PizzaShoppe.WebUI.HtmlHelper
{
    public struct OrderStruct
    {
        public IAppetizerRepository Appetizers;
        public IBeverageRepository Beverages;
        public ICrustRepository Crusts;
        public ISpecialtyPizzaRepository Special;
        public IToppingRepository Toppings;
    }
}