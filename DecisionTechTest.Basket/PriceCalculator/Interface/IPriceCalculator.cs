using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket.PriceCalculator.Interface
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(IEnumerable<IProduct> products);
    }
}
