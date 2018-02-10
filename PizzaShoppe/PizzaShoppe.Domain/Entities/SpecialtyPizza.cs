using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class SpecialtyPizza
    {
        public int PizzaID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SmallPrice { get; set; }
        public decimal MedPrice { get; set; }
        public decimal LargePrice { get; set; }
        public string Size { get; set; }
    }
}
