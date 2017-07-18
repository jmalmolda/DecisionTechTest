using System;
using System.Collections.Generic;
using System.Linq;
using DecisionTechTest.Basket.PriceCalculator.Interface;
using DecisionTechTest.Basket.Products.Implementation;
using DecisionTechTest.Basket.Products.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Should.Fluent;

namespace DecisionTechTest.Basket.Tests
{
    [TestClass]
    public class GivenPriceCalculator
    {
        [TestMethod]
        public void WhenCalculatePriceNoProducts_ThenPrice0()
        {
            // create system under test
            PriceCalculator.Implementation.PriceCalculator priceCalculator =
                new PriceCalculator.Implementation.PriceCalculator();

            // execute test
            decimal result = priceCalculator.CalculatePrice(new List<IProduct>());

            // assert the method call with right parameters
            result.Should().Equal(0M);
        }


        [TestMethod]
        public void WhenCalculatePrice_ThenPriceSumOfProductCosts()
        {
            const decimal priceProduct1 = 1;
            const decimal priceProduct2 = 2;

            // set up dependencies
            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);

            IProduct product2 = Substitute.For<IProduct>();
            product2.Cost.Returns(priceProduct2);

            // create system under test
            PriceCalculator.Implementation.PriceCalculator priceCalculator =
                new PriceCalculator.Implementation.PriceCalculator();

            // execute test
            decimal result = priceCalculator.CalculatePrice(new List<IProduct> { product1, product2 });

            // assert the method call with right parameters
            result.Should().Equal(priceProduct1 + priceProduct2);
        }
    }
}
