using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.PriceCalculator.Interface;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket.PriceCalculator.Implementation
{
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculatePrice(IEnumerable<IProduct> products)
        {
            throw new NotImplementedException();
        }
    }
}
