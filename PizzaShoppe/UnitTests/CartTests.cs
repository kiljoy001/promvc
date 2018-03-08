using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.Domain.Entities;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {
        private Tuple<PizzaShoppe.Domain.Concrete.MenuItem[], Cart> Setup_test()
        {
            PizzaShoppe.Domain.Concrete.MenuItem[] fakeitems = new PizzaShoppe.Domain.Concrete.MenuItem[]
            {
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 1, Name = "M1", Price = 14M },
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 2, Name = "M2", Price = 1.25M },
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 3, Name = "M3", Price = 3M }
            };
            
            Cart target = new Cart();
            var value_store = new Tuple<PizzaShoppe.Domain.Concrete.MenuItem[], Cart>(fakeitems, target);
            return value_store;
        }

        private Tuple<PizzaShoppe.Domain.Concrete.MenuItem[], CustomPizza> Setup_Pizza_Test()
        {
            PizzaShoppe.Domain.Concrete.MenuItem[] fakeitems = new PizzaShoppe.Domain.Concrete.MenuItem[]
            {
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 1, Name = "C1", Price = 14M, Category = "Crust" },
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 2, Name = "T1", Price = 1.25M, Category ="Topping" },
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 3, Name = "T2", Price = 3M, Category ="Topping" },
                new PizzaShoppe.Domain.Concrete.MenuItem { ProductID = 4, Name = "T3", Price = 1.5M, Category ="Topping" }
            };

            CustomPizza target = new CustomPizza(fakeitems[0]);
            var value_store = new Tuple<PizzaShoppe.Domain.Concrete.MenuItem[], CustomPizza>(fakeitems, target);
            return value_store;
        }
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            //Arrange
            var setup = Setup_test();
            var cart = setup.Item2;
            var itemArray = setup.Item1;

            //act
            cart.AddItem(itemArray[0], 1);
            cart.AddItem(itemArray[1], 3);
            cart.AddItem(itemArray[2], 5);
            cart.AddItem(itemArray[1], 1);

            CartLine[] results = cart.Lines.ToArray();

            //assert
            Assert.AreEqual(3, results.Length);
            Assert.AreEqual("M1", results[0].menuItem.Name);
            Assert.AreEqual("M2", results[1].menuItem.Name);
            Assert.AreEqual("M3", results[2].menuItem.Name);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Exisisting_Lines()
        {
            //Arrange
            var setup = Setup_test();
            var cart = setup.Item2;
            var itemArray = setup.Item1;

            //Act
            cart.AddItem(itemArray[0], 1);
            cart.AddItem(itemArray[1], 3);
            cart.AddItem(itemArray[2], 5);
            cart.AddItem(itemArray[1], 7);
            CartLine[] results = cart.Lines.OrderBy(c => c.menuItem.ProductID).ToArray();

            //Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[1].Quantity, 10);
            Assert.AreEqual(results[0].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            //Arrange
            var setup = Setup_test();
            var cart = setup.Item2;
            var itemArray = setup.Item1;

            cart.AddItem(itemArray[0], 1);
            cart.AddItem(itemArray[1], 3);
            cart.AddItem(itemArray[2], 5);
            cart.AddItem(itemArray[1], 7);

            //Act
            cart.RemoveLine(itemArray[0]);

            //Assert
            Assert.AreEqual(cart.Lines.Where(c => c.menuItem == itemArray[0]).Count(), 0);
        }

        [TestMethod]
        public void Calculate_Cart_Menu_Total()
        {
            //Arrange
            var setup = Setup_test();
            var cart = setup.Item2;
            var itemArray = setup.Item1;
            cart.AddItem(itemArray[0], 1);
            cart.AddItem(itemArray[1], 1);
            cart.AddItem(itemArray[2], 1);
            //Act
            decimal result = cart.ComputeTotalValue();
            //Assert
            Assert.AreEqual(18.25M, result);
        }

        [TestMethod]
        public void Calculate_Cart_Custom_Pizza_And_Menu_Total()
        {
            //Arrange
            var setupPizza = Setup_Pizza_Test();
            var customPizza = setupPizza.Item2;
            var pizzaArray = setupPizza.Item1;
            var setupMenu = Setup_test();
            var cart = setupMenu.Item2;
            var itemArray = setupMenu.Item1;

            //Add the toppings
            customPizza.AddItem(pizzaArray[1], 1);
            customPizza.AddItem(pizzaArray[2], 1);
            customPizza.AddItem(pizzaArray[3], 1);
            //Add Menus items
            cart.AddItem(itemArray[0], 1);
            cart.AddItem(itemArray[1], 1);
            cart.AddItem(itemArray[2], 1);
            
            //Add pizza to cart
            cart.AddCPizza(customPizza);

            //Act
            decimal result = cart.ComputeTotalValue();
            //Assert
            Assert.AreEqual(38M, result);
        }
    }
}
