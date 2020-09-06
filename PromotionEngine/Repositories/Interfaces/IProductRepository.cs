using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product FindProduct(string sku);
    }
}
