﻿using PizzaShoppe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Abstract
{
    public interface IToppingRepository
    {
        IEnumerable<Topping> ToppingsLists { get; }
    }
}
