using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Data
{
    public static class ProductList
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                SKU="A",
                Cost=50.0m
            },
            new Product
            {
                SKU="B",
                Cost=30.0m
            },
            new Product
            {
                SKU="C",
                Cost=20.0m
            },
            new Product
            {
                SKU="D",
                Cost=15.0m
            }
        };
    }
}
