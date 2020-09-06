using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Handler
{
    public class PromotionOnAHandler : PromotionHandler
    {
        public override void ApplyPromotion(Cart request)
        {
            if (request != null && request.Lines.Count > 0)
            {
                request.Total = 0.0m;
                var lineA = request.Lines.Where(x => x.Product.SKU == "A").FirstOrDefault();
                if (lineA != null)
                {
                    var modulo = lineA.Quantity % 3;
                    var dividend = lineA.Quantity / 3;
                    request.Total += modulo * lineA.Product.Cost + (dividend * 130);
                }
                if (NextPromotion != null)
                {
                    NextPromotion.ApplyPromotion(request);
                }
            }
            Console.WriteLine("No Items Added in Cart");
        }
    }
}
