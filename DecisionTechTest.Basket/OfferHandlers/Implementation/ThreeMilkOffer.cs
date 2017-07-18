using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.Products.Implementation;

namespace DecisionTechTest.Basket.OfferHandlers.Implementation
{
    public class ThreeMilkOffer : OfferHandler
    {
        public override List<ProductProcessedCost> ApplyOffer(List<ProductProcessedCost> products)
        {
            for (int index = 0; index < products.Count; index++)
            {
                var product = products[index];
                // check if we can apply the offer
                if (product.Product is Milk 
                    && !product.IsProcessed
                    && products.Count(p => p.Product is Milk && !p.IsProcessed) > 3)
                {
                    product.Product.Cost = 0M;
                    product.IsProcessed = true;
                    // modify the products of the list relevant to the offer
                    var usedProductIndex = products.FindIndex(p => p.Product is Milk && !p.IsProcessed);
                    products[usedProductIndex].IsProcessed = true;
                    usedProductIndex = products.FindIndex(p => p.Product is Milk && !p.IsProcessed);
                    products[usedProductIndex].IsProcessed = true;
                    usedProductIndex = products.FindIndex(p => p.Product is Milk && !p.IsProcessed);
                    products[usedProductIndex].IsProcessed = true;
                }
            }

            return products;
        }
    }
}
