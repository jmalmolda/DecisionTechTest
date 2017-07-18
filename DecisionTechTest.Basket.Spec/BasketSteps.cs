using System;
using DecisionTechTest.Basket.Products.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace DecisionTechTest.Basket.Spec
{
    [Binding]
    public class BasketSteps
    {
        private Basket basket = new Basket(new PriceCalculator.Implementation.PriceCalculator());
        private decimal totalPrice = 0.0M;
        [Given(@"I have added a bread product to the basket")]
        public void GivenIHaveAddedABreadProductToTheBasket()
        {
            basket.AddProduct(new Bread());
        }
        
        [Given(@"I have added a butter product to the basket")]
        public void GivenIHaveAddedAButterProductToTheBasket()
        {
            basket.AddProduct(new Butter());
        }

        [Given(@"I have added a milk product to the basket")]
        public void GivenIHaveAddedAMilkProductToTheBasket()
        {
            basket.AddProduct(new Milk());

        }

        [When(@"I get the total price")]
        public void WhenIGetTheTotalPrice()
        {
            totalPrice = basket.GetTotalPrice();
        }
        
        [Then(@"the result should be £(.*)")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            Assert.AreEqual(totalPrice, p0);
        }
    }
}
