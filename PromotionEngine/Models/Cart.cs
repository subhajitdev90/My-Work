using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Id = System.Guid.NewGuid().ToString();
            this.Lines = new List<CartLine>();
        }
        public string Id { get; set; }
        public List<CartLine> Lines { get; set; }
        public decimal Total { get; set; }
    }
}
