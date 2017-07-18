using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Model;
using DecisionTechTest.Basket.OfferHandlers.Interface;

namespace DecisionTechTest.Basket.OfferHandlers.Implementation
{
    public abstract class OfferHandler : IOfferHandler
    {
        public List<ProductProcessedCost> ApplyOffer(List<ProductProcessedCost> products)
        {
            throw new NotImplementedException();
        }
    }
}
