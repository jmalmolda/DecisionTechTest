using System;
using System.Collections.Generic;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.OfferHandlers.Implementation;
using DecisionTechTest.Basket.Products.Implementation;
using DecisionTechTest.Basket.Products.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Should.Fluent;

namespace DecisionTechTest.Basket.Tests
{
    [TestClass]
    public class GivenTwoButterOffer
    {
        [TestMethod]
        public void WhenApplyOfferNo2Butter_ThenReturnSameList()
        {
            const decimal priceProduct1 = 1;
            const decimal priceProduct2 = 2;

            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);
            IProduct product2 = Substitute.For<IProduct>();
            product2.Cost.Returns(priceProduct2);

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
            };

            // create system under test
            TwoButterOffer offer = new TwoButterOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(2);
            result[0].Product.Cost.Should().Equal(1);
            result[0].IsProcessed.Should().Be.False();
            result[1].Product.Cost.Should().Equal(1);
            result[1].IsProcessed.Should().Be.False();
        }

        [TestMethod]
        public void WhenApplyOfferWith2Butter_ThenReturnModified()
        {
            // create dependencies
            const decimal priceProduct1 = 1;
            const decimal priceProduct2 = 2;

            IProduct product1 = Substitute.For<IProduct>();
            product1.Cost.Returns(priceProduct1);
            IProduct product2 = Substitute.For<IProduct>();
            product2.Cost.Returns(priceProduct2);

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
            };

            // create system under test
            TwoButterOffer offer = new TwoButterOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(2);
            result[0].Product.Cost.Should().Equal(1);
            result[0].IsProcessed.Should().Be.False();
            result[1].Product.Cost.Should().Equal(1);
            result[1].IsProcessed.Should().Be.False();
        }
    }
}
