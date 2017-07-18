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
            ThreeMilkOffer offer = new ThreeMilkOffer();

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
            ThreeMilkOffer offer = new ThreeMilkOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(4);
            result[0].Product.Cost.Should().Equal(0M);
            result[0].IsProcessed.Should().Be.True();
            result[1].Product.Cost.Should().Equal(1.15M);
            result[1].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(1.15M);
            result[2].IsProcessed.Should().Be.True();
            result[3].Product.Cost.Should().Equal(1.15M);
            result[3].IsProcessed.Should().Be.True();
        }

        [TestMethod]
        public void WhenApplyOfferWith8Milk_ThenReturnModified()
        {
            Milk product1 = new Milk();
            Milk product2 = new Milk();
            Milk product3 = new Milk();
            Milk product4 = new Milk();
            Milk product5 = new Milk();
            Milk product6 = new Milk();
            Milk product7 = new Milk();
            Milk product8 = new Milk();

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
                new ProductProcessedCost {Product = product3, IsProcessed = false},
                new ProductProcessedCost {Product = product4, IsProcessed = false},
                new ProductProcessedCost {Product = product5, IsProcessed = false},
                new ProductProcessedCost {Product = product6, IsProcessed = false},
                new ProductProcessedCost {Product = product7, IsProcessed = false},
                new ProductProcessedCost {Product = product8, IsProcessed = false},
            };

            // create system under test
            ThreeMilkOffer offer = new ThreeMilkOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(8);
            result[0].Product.Cost.Should().Equal(0M);
            result[0].IsProcessed.Should().Be.True();
            result[1].Product.Cost.Should().Equal(1.15M);
            result[1].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(1.15M);
            result[2].IsProcessed.Should().Be.True();
            result[3].Product.Cost.Should().Equal(1.15M);
            result[3].IsProcessed.Should().Be.True();
            result[4].Product.Cost.Should().Equal(0M);
            result[4].IsProcessed.Should().Be.True();
            result[5].Product.Cost.Should().Equal(1.15M);
            result[5].IsProcessed.Should().Be.True();
            result[6].Product.Cost.Should().Equal(1.15M);
            result[6].IsProcessed.Should().Be.True();
            result[7].Product.Cost.Should().Equal(1.15M);
            result[7].IsProcessed.Should().Be.True();
        }

    }
}
