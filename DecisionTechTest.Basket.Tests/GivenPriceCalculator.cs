using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.OfferHandlers.Implementation;
using DecisionTechTest.Basket.OfferHandlers.Interface;
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
        public void WhenCalculatePriceWithOfferHandler_ThenOfferHandlerCalled()
        {
            const decimal priceProduct1 = 1;
            const decimal priceProduct2 = 2;

            // set up dependencies
            ProductProcessedCost productCost1 = new ProductProcessedCost { Cost = priceProduct1, IsProcessed = true };
            ProductProcessedCost productCost2 = new ProductProcessedCost { Cost = priceProduct2, IsProcessed = true };

            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);

            // create a handler stub that always returns a list of productCost1 and productCost2
            var handler = Substitute.For<IOfferHandler>();

            handler.ApplyOffer(Arg.Any<List<ProductProcessedCost>>())
                .Returns(new List<ProductProcessedCost> { productCost1, productCost2 });

            // create system under test
            PriceCalculator.Implementation.PriceCalculator priceCalculator =
                new PriceCalculator.Implementation.PriceCalculator(handler);

            // execute test
            decimal result = priceCalculator.CalculatePrice(new List<IProduct>() { product1 });

            // assert call to handler with product1 unprocessed
            handler.Received()
                .ApplyOffer(
                    Arg.Is<List<ProductProcessedCost>>(list => list.Any(pc => pc.Cost == priceProduct1 && !pc.IsProcessed)));

            // assert the result
            result.Should().Equal(priceProduct1 + priceProduct2);
        }
    }
}
