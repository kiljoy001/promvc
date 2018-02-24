using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShoppe.Domain.Entities
{
    public class CustomPizza :ICart
    {
        private MenuItem CrustType; 
        private List<CartLine> SelectedToppings = new List<CartLine>();

        public CustomPizza(MenuItem crust)
        {
            //Ensure that only items with the crust property
            if (crust.Category =="Crust")
            {
                CrustType = crust;
            }
            else
            {
                //Throw an error if something incorrect is passed.
                throw new ArgumentException();
            }
           
        }

        public void AddItem(MenuItem item, int quantity)
        {
            //Ensure that only items with the Toppings or curst property can be added
            if(item.Category == "Topping" || item.Category == "Crust" && CrustType == null)
            {
                CartLine line = SelectedToppings.Where(i => i.menuItem.ProductID == item.ProductID).FirstOrDefault();
                if (line == null)
                {
                    SelectedToppings.Add(new CartLine { menuItem = item, Quantity = quantity });
                }
                else
                {
                    line.Quantity += quantity;
                }
            }
            else
            {
                //Throw an error if something incorrect is passed.
                throw new ArgumentException();
            }
        }

        public void RemoveLine(MenuItem item)
        {
            //Ensure that item is crust or topping type. All others throws exception
            if(item.Category == "Topping" || item.Category == "Crust")
            {
                SelectedToppings.RemoveAll(l => l.menuItem.ProductID == item.ProductID);
            }
            else
            {
                throw new ArgumentException();
            }
            
        }

        public decimal ComputeTotalValue()
        {
            decimal subtotal = 0;
            foreach(CartLine item in SelectedToppings)
            {
                subtotal += item.menuItem.Price * item.Quantity;
            }
            return subtotal + CrustType.Price;
        }

        public void Clear()
        {
            SelectedToppings.Clear();
            CrustType = null;
        }

        public IEnumerable<CartLine> Lines { get { return SelectedToppings; } }
        public MenuItem Crust { get { return CrustType; } }
        public decimal Price { get { return this.ComputeTotalValue(); } }

    }

    
}
