using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using PizzaShoppe.Domain.Abstract;
using PizzaShoppe.Domain.Entities;

namespace PizzaShoppe.WebUI.Infrastructure
{
    public class NinjsectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjsectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService (Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IAppetizerRepository> app = new Mock<IAppetizerRepository>();
            app.Setup(a => a.AppetizersList).Returns(new List<Appetizer>
            {
                new Appetizer {Name = "Crispy Cauliflower", Price = 8 },
                new Appetizer{Name= "Onion Rings", Price = 7},
                new Appetizer{Name="Garlic Provolone Breadsticks", Price =6}
            });

            Mock<IBeverageRepository> bev = new Mock<IBeverageRepository>();
            bev.Setup(b => b.BeveragesList).Returns(new List<Beverage>
                {
                    new Beverage {Name="Draft Beer", Price =4m},
                    new Beverage {Name ="House Red", Price=5m},
                    new Beverage{Name="House White", Price=5m}
                });
            Mock<ICrustRepository> crusts = new Mock<ICrustRepository>();
            crusts.Setup(c => c.CrustsLists).Returns(new List<Crust>
            {
                new Crust {Name="Orignal", LargePrice=14m, MedPrice=12m, SmallPrice=9m},
                new Crust {Name="Thin", SmallPrice=6m, MedPrice=10m, LargePrice=13m},
                new Crust {Name="Cheese Stuffed", SmallPrice= 10m, MedPrice=14m, LargePrice=20m}
            });
            Mock<ISpecialtyPizzaRepository> special = new Mock<ISpecialtyPizzaRepository>();
            special.Setup(s => s.PizzasLists).Returns(new List<SpecialtyPizza>
            {
                new SpecialtyPizza {Name ="Cosmic Chicken", SmallPrice=13m, MedPrice=17m, LargePrice=20m},
                new SpecialtyPizza {Name="Peperoni Perfection", SmallPrice=13m, MedPrice=17m, LargePrice=20m},
                new SpecialtyPizza {Name="Spicy Monkey", SmallPrice=11m, MedPrice=15m, LargePrice=19m}
            });
            Mock<IToppingRepository> top = new Mock<IToppingRepository>();
            top.Setup(t => t.ToppingsLists).Returns(new List<Topping>
            {
                new Topping{Name="Peperoni", Price=2.25m},
                new Topping{Name="Bacon", Price=2.25m},
                new Topping{Name="Egg", Price=2.25m}
            });

            kernel.Bind<IAppetizerRepository>().ToConstant(app.Object);
            kernel.Bind<IBeverageRepository>().ToConstant(bev.Object);
            kernel.Bind<ICrustRepository>().ToConstant(crusts.Object);
            kernel.Bind<ISpecialtyPizzaRepository>().ToConstant(special.Object);
            kernel.Bind<IToppingRepository>().ToConstant(top.Object);
        }
    }
}