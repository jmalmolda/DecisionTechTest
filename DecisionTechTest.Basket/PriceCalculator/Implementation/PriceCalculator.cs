using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.OfferHandlers.Interface;
using DecisionTechTest.Basket.PriceCalculator.Interface;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket.PriceCalculator.Implementation
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IOfferHandler _handler;

        public PriceCalculator(IOfferHandler handler)
        {
            _handler = handler;
        }

        public decimal CalculatePrice(IEnumerable<IProduct> products)
        {
            List<ProductProcessedCost> processedProducts = products
                .Select(product => new ProductProcessedCost
                {               
                    Product = product,
                    IsProcessed = false
                }).ToList();

            processedProducts = _handler.ApplyOffer(processedProducts);

            return processedProducts?.Sum(processedProduct => processedProduct.Product.Cost) ?? 0M;
        }
    }
}
