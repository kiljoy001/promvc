using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaShoppe.Domain.Concrete;
using PizzaShoppe.Domain.Entities;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class CustomPizzaTest
    {
        private Tuple<PizzaShoppe.Domain.Concrete.MenuItem[], CustomPizza> Setup_test()
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
        public void Can_Add_New_Toppings()
        {
            //Arrange
            var setup = Setup_test();
            var customPizza = setup.Item2;
            var itemArray = setup.Item1;

            //act

            customPizza.AddItem(itemArray[1], 3);
            customPizza.AddItem(itemArray[2], 3);
            customPizza.AddItem(itemArray[3], 1);

            CartLine[] results = customPizza.Lines.ToArray();

            //assert
            Assert.AreEqual(3, results.Length);
            Assert.AreEqual("T1", results[0].menuItem.Name);
            Assert.AreEqual("T2", results[1].menuItem.Name);
            Assert.AreEqual("T3", results[2].menuItem.Name);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Exisisting_Toppings()
        {
            //Arrange
            var setup = Setup_test();
            var customPizza = setup.Item2;
            var itemArray = setup.Item1;

            //Act
            customPizza.AddItem(itemArray[1], 3);
            customPizza.AddItem(itemArray[2], 5);
            customPizza.AddItem(itemArray[1], 7);
            CartLine[] results = customPizza.Lines.ToArray();

            //Assert
            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(10, results[0].Quantity);
            Assert.AreEqual(5, results[1].Quantity);
        }

        [TestMethod]
        public void Can_Remove_All_Toppings_Line()
        {
            //Arrange
            var setup = Setup_test();
            var customPizza = setup.Item2;
            var itemArray = setup.Item1;

            customPizza.AddItem(itemArray[1], 3);
            customPizza.AddItem(itemArray[2], 5);
            customPizza.AddItem(itemArray[1], 7);

            //Act
            customPizza.RemoveLine(itemArray[1]);

            //Assert
            Assert.AreEqual(0, customPizza.Lines.Where(c => c.menuItem == itemArray[1]).Count());
        }

        [TestMethod]
        public void Calculate_customPizza_Total()
        {
            //Arrange
            var setup = Setup_test();
            var customPizza = setup.Item2;
            var itemArray = setup.Item1;

            customPizza.AddItem(itemArray[1], 1);
            customPizza.AddItem(itemArray[2], 1);
            customPizza.AddItem(itemArray[3], 1);
            //Act
            decimal result = customPizza.ComputeTotalValue();
            //Assert
            Assert.AreEqual(19.75M, result);
        }
    }
}

