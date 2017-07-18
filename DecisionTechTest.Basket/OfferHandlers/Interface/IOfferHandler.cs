using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Model;

namespace DecisionTechTest.Basket.OfferHandlers.Interface
{
    public interface IOfferHandler
    {
        List<ProductProcessedCost> ApplyOffer(List<ProductProcessedCost> products);
    }
}
