using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class Cart: ICart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        private List<CustomPizza> customPizzas = new List<CustomPizza>();

        public void AddItem(MenuItem item, int quantity)
        {
            CartLine line = lineCollection.Where(i => i.menuItem.ProductID == item.ProductID).FirstOrDefault();
            if(line == null)
            {
                lineCollection.Add(new CartLine { menuItem = item, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void AddCPizza(CustomPizza customPizza)
        {
            customPizzas.Add(customPizza);
        }

        public void RemoveLine(MenuItem item)
        {
            lineCollection.RemoveAll(l => l.menuItem.ProductID == item.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            decimal menu_subtotal = lineCollection.Sum(e => e.menuItem.Price * e.Quantity);
            decimal cPizzaTotal = customPizzas.Sum(p => p.Price);
            return menu_subtotal + cPizzaTotal;
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines { get { return lineCollection; } }
        public IEnumerable<CustomPizza> Custom { get { return customPizzas; } }
    }
}
