using System;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace DecisionTechTest.Basket.Tests
{
    [TestClass]
    public class GivenMilk
    {
        [TestMethod]
        public void WhenCost_ThenResultIs1pound15pence()
        {
            // create system under test
            Milk bread = new Milk();

            // execute test
            decimal cost = bread.Cost;

            // assert the result
            cost.Should().Equal(1.15M);
        }
    }
}
