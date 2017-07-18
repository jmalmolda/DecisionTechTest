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
            result[0].Product.Cost.Should().Equal(1M);
            result[0].IsProcessed.Should().Be.False();
            result[1].Product.Cost.Should().Equal(1M);
            result[1].IsProcessed.Should().Be.False();
        }

        [TestMethod]
        public void WhenApplyOfferWith2Butter1Bread_ThenReturnModified()
        {
            Butter product1 = new Butter();
            Butter product2 = new Butter();
            Bread product3 = new Bread();

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
                new ProductProcessedCost {Product = product3, IsProcessed = false},
            };

            // create system under test
            TwoButterOffer offer = new TwoButterOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(3);
            result[0].Product.Cost.Should().Equal(0.8M);
            result[0].IsProcessed.Should().Be.True();
            result[1].Product.Cost.Should().Equal(0.8M);
            result[1].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(0.5M);
            result[2].IsProcessed.Should().Be.True();
        }

        [TestMethod]
        public void WhenApplyOfferWith4Butter2Bread_ThenReturnModified()
        {
            Butter product1 = new Butter();
            Butter product2 = new Butter();
            Bread product3 = new Bread();
            Butter product4 = new Butter();
            Butter product5 = new Butter();
            Bread product6 = new Bread();

            // create dependencies
            var products = new List<ProductProcessedCost>
            {
                new ProductProcessedCost {Product = product1, IsProcessed = false},
                new ProductProcessedCost {Product = product2, IsProcessed = false},
                new ProductProcessedCost {Product = product3, IsProcessed = false},
                new ProductProcessedCost {Product = product4, IsProcessed = false},
                new ProductProcessedCost {Product = product5, IsProcessed = false},
                new ProductProcessedCost {Product = product6, IsProcessed = false},
            };

            // create system under test
            TwoButterOffer offer = new TwoButterOffer();

            // execute test
            List<ProductProcessedCost> result = offer.ApplyOffer(products);

            // assert the result
            result.Count.Should().Equal(6);
            result[0].Product.Cost.Should().Equal(0.8M);
            result[0].IsProcessed.Should().Be.True();
            result[1].Product.Cost.Should().Equal(0.8M);
            result[1].IsProcessed.Should().Be.True();
            result[2].Product.Cost.Should().Equal(0.5M);
            result[2].IsProcessed.Should().Be.True();
            result[3].Product.Cost.Should().Equal(0.8M);
            result[3].IsProcessed.Should().Be.True();
            result[4].Product.Cost.Should().Equal(0.8M);
            result[4].IsProcessed.Should().Be.True();
            result[5].Product.Cost.Should().Equal(0.5M);
            result[5].IsProcessed.Should().Be.True();
        }
    }
}
