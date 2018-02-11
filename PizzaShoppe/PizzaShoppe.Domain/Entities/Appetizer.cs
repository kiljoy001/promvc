using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class Appetizer
    {
        [Key]
        public int AppID { get; set; }
        public string Name { get; set; }
        public decimal SmallPrice { get; set; }
        public decimal LargePrice { get; set; }
        public string Description { get; set; }
    }
}
