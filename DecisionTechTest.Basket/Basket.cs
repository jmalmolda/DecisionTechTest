using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.PriceCalculator.Interface;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket
{
    public class Basket
    {
        private readonly IPriceCalculator _calculator;

        public Basket(IPriceCalculator calculator)
        {
            _calculator = calculator;
        }

        public void AddProduct(IProduct product)
        {
            throw new NotImplementedException();
        }

        public decimal GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
