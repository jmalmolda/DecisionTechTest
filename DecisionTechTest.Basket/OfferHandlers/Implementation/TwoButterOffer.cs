using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.Products.Implementation;

namespace DecisionTechTest.Basket.OfferHandlers.Implementation
{
    public class TwoButterOffer : OfferHandler
    {
        public override List<ProductProcessedCost> ApplyOffer(List<ProductProcessedCost> products)
        {
            for (int index = 0; index < products.Count; index++)
            {
                var product = products[index];
                // check if we can apply the offer
                if (product.Product is Bread && products.Count(p => p.Product is Butter && !p.IsProcessed) > 1)
                {
                    // modify the products of the list relevant to the offer
                    var usedProductIndex = products.FindIndex(p => p.Product is Butter && !p.IsProcessed);
                    products[usedProductIndex].IsProcessed = true;
                    usedProductIndex = products.FindIndex(p => p.Product is Butter && !p.IsProcessed);
                    products[usedProductIndex].IsProcessed = true;
                    product.Product.Cost = 0.5M;
                    product.IsProcessed = true;
                }
            }

            return products;
        }
    }
}
