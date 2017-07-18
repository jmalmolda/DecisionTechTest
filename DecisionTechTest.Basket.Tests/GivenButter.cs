using System;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace DecisionTechTest.Basket.Tests
{
    [TestClass]
    public class GivenButter
    {
        [TestMethod]
        public void WhenCost_ThenResultIs80pence()
        {
            // create system under test
            Butter bread = new Butter();

            // execute test
            decimal cost = bread.Cost;

            // assert the result
            cost.Should().Equal(0.8M);
        }
    }
}
