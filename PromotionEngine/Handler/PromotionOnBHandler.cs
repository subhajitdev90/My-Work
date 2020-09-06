using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Handler
{
    public class PromotionOnBHandler : PromotionHandler
    {
        public override void ApplyPromotion(Cart request)
        {
            if (request != null && request.Lines.Count > 0)
            {
                var lineB = request.Lines.Where(x => x.Product.SKU == "B").FirstOrDefault();                
                if (lineB != null)
                {
                    var modulo = lineB.Quantity % 2;
                    var dividend = lineB.Quantity / 2;
                    request.Total += modulo * lineB.Product.Cost + (dividend * 45);

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
