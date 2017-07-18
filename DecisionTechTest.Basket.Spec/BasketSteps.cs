using System;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DecisionTechTest.Basket.Spec
{
    [Binding]
    public class BasketSteps
    {
        private readonly Basket _basket = new Basket(new PriceCalculator.Implementation.PriceCalculator());
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
    }
}
