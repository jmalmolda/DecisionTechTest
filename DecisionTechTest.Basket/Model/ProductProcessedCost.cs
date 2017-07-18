using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Products.Implementation;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket.Model
{
    public class ProductProcessedCost
    {
        public IProduct Product { get; set; }
        public bool IsProcessed { get; set; }
    }
}
