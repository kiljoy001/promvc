using PizzaShoppe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaShoppe.WebUI.Infrastructure.Binder
{
    public class CartModelBinder : IModelBinder
    {
        private const string SessionKey = "Cart";

        public object BindModel(ControllerContext Ccontext, ModelBindingContext Mcontext)
        {
            //Get cart from session
            Cart cart = null;
            if(Ccontext.HttpContext.Session != null)
            {
                cart = (Cart)Ccontext.HttpContext.Session[SessionKey];
            }
            //Create cart from session if it does not exist
            if(cart == null)
            {
                cart = new Cart();
                if(Ccontext.HttpContext.Session != null)
                {
                    Ccontext.HttpContext.Session[SessionKey] = cart;
                }
            }
            return cart;
        }
    }
}