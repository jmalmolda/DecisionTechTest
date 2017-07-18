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
        private readonly List<IOfferHandler> _handlers;

        public PriceCalculator(List<IOfferHandler> handlers)
        {
            _handlers = handlers;
        }

        public decimal CalculatePrice(IEnumerable<IProduct> products)
        {
            List<ProductProcessedCost> processedProducts = products
                .Select(product => new ProductProcessedCost
                {               
                    Product = product,
                    IsProcessed = false
                }).ToList();
            foreach (var handler in _handlers)
            {
                processedProducts = handler.ApplyOffer(processedProducts);
            }

            return processedProducts?.Sum(processedProduct => processedProduct.Product.Cost) ?? 0M;
        }
    }
}
