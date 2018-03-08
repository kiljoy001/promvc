using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaShoppe.Domain.Entities;

namespace PizzaShoppe.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<MenuItem> Products { get; }
    }
}
