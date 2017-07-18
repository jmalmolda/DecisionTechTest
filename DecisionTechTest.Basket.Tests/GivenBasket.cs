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
    public class GivenBasket
    {
        [TestMethod]
        public void WhenTotalPrice_ThenPriceCalculatorIsCalledWithRighProducts()
        {
            // set up dependencies
            IPriceCalculator priceCalculator = Substitute.For<IPriceCalculator>();

            // create system under test
            Basket basket = new Basket(priceCalculator);

            // execute test
            basket.AddProduct(new Bread());
            basket.AddProduct(new Milk());
            basket.AddProduct(new Butter());
            basket.GetTotalPrice();

            // assert the method call with right parameters
            priceCalculator.Received().CalculatePrice(Arg.Is<IEnumerable<IProduct>>(
                products => products.Any(p => p is Bread) && products.Any(p => p is Butter)
                && products.Any(p => p is Milk)));
        }

        [TestMethod]
        public void WhenTotalPrice_ThenPriceCalculatorResultIsReturned()
        {
            // random total price
            const decimal totalPrice = 10M;

            // set up dependencies
            IPriceCalculator priceCalculator = Substitute.For<IPriceCalculator>();
            priceCalculator.CalculatePrice(Arg.Any<IEnumerable<IProduct>>()).Returns(totalPrice);

            // create system under test
            Basket basket = new Basket(priceCalculator);

            // execute test
            decimal result = basket.GetTotalPrice();

            // assert the method call with right parameters
            result.Should().Equal(totalPrice);
        }
    }
}
