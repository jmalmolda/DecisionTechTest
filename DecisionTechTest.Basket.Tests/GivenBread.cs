using System;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace DecisionTechTest.Basket.Tests
{
    [TestClass]
    public class GivenBread
    {
        [TestMethod]
        public void WhenCost_ThenResultIs1pound()
        {
            // create system under test
            Bread bread = new Bread();

            // execute test
            decimal cost = bread.Cost;

            // assert the result
            cost.Should().Equal(1.00M);
        }
    }
}
