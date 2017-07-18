using System;
using System.Collections.Generic;
using DecisionTechTest.Basket.OfferHandlers.Implementation;
using DecisionTechTest.Basket.OfferHandlers.Interface;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DecisionTechTest.Basket.Spec
{
    [Binding]
    public class BasketSteps
    {
        private static readonly List<IOfferHandler> Handler = new List<IOfferHandler>
        {
            new TwoButterOffer(),
            new ThreeMilkOffer()
        };
        private static readonly PriceCalculator.Implementation.PriceCalculator Calculator =
            new PriceCalculator.Implementation.PriceCalculator(Handler);
        private readonly Basket _basket = new Basket(Calculator);
        private decimal _totalPrice = 0.0M;
        [Given(@"I have added a bread product to the basket")]
        public void GivenIHaveAddedABreadProductToTheBasket()
        {
            _basket.AddProduct(new Bread());
        }

        [Given(@"I have added a butter product to the basket")]
        public void GivenIHaveAddedAButterProductToTheBasket()
        {
            _basket.AddProduct(new Butter());
        }

        [Given(@"I have added a milk product to the basket")]
        public void GivenIHaveAddedAMilkProductToTheBasket()
        {
            _basket.AddProduct(new Milk());

        }

        [When(@"I get the total price")]
        public void WhenIGetTheTotalPrice()
        {
            _totalPrice = _basket.GetTotalPrice();
        }

        [Then(@"the result should be £(.*)")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            Assert.AreEqual(_totalPrice, p0);
        }

        [Given(@"I have added (.*) butter products to the basket")]
        public void GivenIHaveAddedButterProductsToTheBasket(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                _basket.AddProduct(new Butter());
            }
        }

        [Given(@"I have added (.*) bread products to the basket")]
        public void GivenIHaveAddedBreadProductsToTheBasket(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                _basket.AddProduct(new Bread());
            }
        }

        [Given(@"I have added (.*) milk products to the basket")]
        public void GivenIHaveAddedMilkProductsToTheBasket(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                _basket.AddProduct(new Milk());
            }
        }

    }
}
