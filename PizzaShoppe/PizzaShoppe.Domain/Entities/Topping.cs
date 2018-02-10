﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class Topping
    {
        public int ToppingID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ToppingType { get; set; }
    }
}
