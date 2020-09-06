using PromotionEngine.Data;
using PromotionEngine.Models;
using PromotionEngine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product FindProduct(string sku)
        {
            var product = ProductList.Products.Find(x => x.SKU == sku);
            return product;
        }
    }
}
