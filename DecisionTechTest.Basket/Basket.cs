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
        private List<IProduct> _products;

        public Basket(IPriceCalculator calculator)
        {
            _calculator = calculator;
            _products = new List<IProduct>();
        }


        public void AddProduct(IProduct product)
        {
            _products.Add(product);
        }

        public decimal GetTotalPrice()
        {
            return _calculator.CalculatePrice(_products);
        }
    }
}
