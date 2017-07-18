using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionTechTest.Basket.Products.Interface;

namespace DecisionTechTest.Basket.Products.Implementation
{
    public abstract class Product : IProduct
    {
        public decimal Cost { get; set; }
    }
}
