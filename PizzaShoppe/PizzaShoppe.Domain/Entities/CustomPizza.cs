using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class CustomPizza
    {
        public Crust CrustType { get; set; }
        public IEnumerable<Topping> SelectedToppings { get; set; }
        public string Size { get; set; }
    }
}
