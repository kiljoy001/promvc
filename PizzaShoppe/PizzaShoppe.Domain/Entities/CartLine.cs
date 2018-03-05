using PizzaShoppe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class CartLine
    {
        public MenuItem menuItem { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get { return menuItem.Price * Quantity; } }
    }
}
