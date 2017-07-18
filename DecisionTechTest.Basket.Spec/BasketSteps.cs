using System;
using TechTalk.SpecFlow;

namespace DecisionTechTest.Basket.Spec
{
    [Binding]
    public class BasketSteps
    {
        [Given(@"I have added a bread product to the basket")]
        public void GivenIHaveAddedABreadProductToTheBasket()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added a butter product to the basket")]
        public void GivenIHaveAddedAButterProductToTheBasket()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added a milk product to the basket")]
        public void GivenIHaveAddedAMilkProductToTheBasket()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I get the total price")]
        public void WhenIGetTheTotalPrice()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be £(.*)")]
        public void ThenTheResultShouldBe(Decimal p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
