using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Abstract
{
    public interface ICart
    {
        void AddItem(Concrete.MenuItem item, int quantity);
        void RemoveLine(Concrete.MenuItem item);
        decimal ComputeTotalValue();
        void Clear();
        IEnumerable<CartLine> Lines { get; }
    }
}
