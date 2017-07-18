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
    public class GivenThreeMilkOffer
    {
        [TestMethod]
        public void WhenApplyOfferNo3Milk_ThenReturnSameList()
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
            result[0].Product.Cost.Should().Equal(1M);
            result[0].IsProcessed.Should().Be.False();
            result[1].Product.Cost.Should().Equal(2M);
            result[1].IsProcessed.Should().Be.False();
        }

        [TestMethod]
        public void WhenApplyOfferWith4Milk_ThenReturnModified()
        {
            Milk product1 = new Milk();
            Milk product2 = new Milk();
            Milk product3 = new Milk();
            Milk product4 = new Milk();

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
                new ProductProcessedCost {Product = product3, IsProcessed = false},
                new ProductProcessedCost {Product = product4, IsProcessed = false},
            };

            // create system under test
            TwoButterOffer offer = new TwoButterOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(4);
            result[0].Product.Cost.Should().Equal(1.15M);
            result[0].IsProcessed.Should().Be.True();
            result[1].Product.Cost.Should().Equal(1.15M);
            result[1].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(1.15M);
            result[2].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(0);
            result[2].IsProcessed.Should().Be.True();
        }

    }
}
