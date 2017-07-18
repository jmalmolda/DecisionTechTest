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

            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);
            IProduct product2 = Substitute.For<IProduct>();
            product2.Cost.Returns(priceProduct2);

            // set up dependencies
            ProductProcessedCost productCost1 = new ProductProcessedCost { Product = product1, IsProcessed = true };
            ProductProcessedCost productCost2 = new ProductProcessedCost { Product = product2, IsProcessed = true };


            // create a handler stub that always returns a list of productCost1 and productCost2
            var handler = Substitute.For<IOfferHandler>();

            handler.ApplyOffer(Arg.Any<List<ProductProcessedCost>>())
                .Returns(new List<ProductProcessedCost> { productCost1, productCost2 });

            var handlers = new List<IOfferHandler> {handler};

            // create system under test
            PriceCalculator.Implementation.PriceCalculator priceCalculator =
                new PriceCalculator.Implementation.PriceCalculator(handlers);

            // execute test
            decimal result = priceCalculator.CalculatePrice(new List<IProduct>() { product1 });

            // assert call to handler with product1 unprocessed
            handler.Received()
                .ApplyOffer(
                    Arg.Is<List<ProductProcessedCost>>(list => list.Any(pc => pc.Product.Cost == priceProduct1 && !pc.IsProcessed)));

            // assert the result
            result.Should().Equal(priceProduct1 + priceProduct2);
        }

        [TestMethod]
        public void WhenCalculatePriceWithMultipleOfferHandler_ThenAllOfferHandlersCalled()
        {
            const decimal priceProduct1 = 1;
            const decimal priceProduct2 = 2;

            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);
            IProduct product2 = Substitute.For<IProduct>();
            product2.Cost.Returns(priceProduct2);

            // set up dependencies
            ProductProcessedCost productCost1 = new ProductProcessedCost { Product = product1, IsProcessed = true };
            ProductProcessedCost productCost2 = new ProductProcessedCost { Product = product2, IsProcessed = true };


            // create a handler stub that always returns a list of productCost1 and productCost2
            var handler1 = Substitute.For<IOfferHandler>();

            handler1.ApplyOffer(Arg.Any<List<ProductProcessedCost>>())
                .Returns(new List<ProductProcessedCost> { productCost1, productCost2 });

            // create a handler stub that always returns a list with productCost1
            var handler2 = Substitute.For<IOfferHandler>();

            handler2.ApplyOffer(Arg.Any<List<ProductProcessedCost>>())
                .Returns(new List<ProductProcessedCost> { productCost1 });

            var handlers = new List<IOfferHandler> { handler1, handler2 };

            // create system under test
            PriceCalculator.Implementation.PriceCalculator priceCalculator =
                new PriceCalculator.Implementation.PriceCalculator(handlers);

            // execute test
            decimal result = priceCalculator.CalculatePrice(new List<IProduct>() { product1 });

            // assert the result
            result.Should().Equal(priceProduct1);
        }
    }
}
