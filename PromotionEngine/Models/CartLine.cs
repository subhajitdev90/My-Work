using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class CartLine
    {
        public CartLine()
        {
            this.Id = System.Guid.NewGuid().ToString();
        }
        public Product Product { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
