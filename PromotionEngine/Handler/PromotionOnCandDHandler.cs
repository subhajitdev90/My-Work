using PromotionEngine.Models;
using PromotionEngine.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Handler
{
    public class PromotionOnCandDHandler : PromotionHandler
    {
        public override void ApplyPromotion(Cart request)
        {
            if (request != null && request.Lines.Count > 0)
            {
                var lineC = request.Lines.Where(x => x.Product.SKU == "C").FirstOrDefault();
                var lineD = request.Lines.Where(x => x.Product.SKU == "D").FirstOrDefault();
                if (lineC != null && lineD != null)
                {
                    if (lineC.Quantity == lineD.Quantity)
                    {
                        request.Total += lineC.Quantity * 30;
                    }
                    else if (lineC.Quantity > lineD.Quantity)
                    {
                        request.Total += lineD.Quantity * 30 + (lineC.Quantity - lineD.Quantity) * lineC.Product.Cost;
                    }
                    else if (lineC.Quantity < lineD.Quantity)
                    {
                        request.Total += lineC.Quantity * 30 + (lineD.Quantity - lineC.Quantity) * lineC.Product.Cost;
                    }
                }
                else if (lineC != null)
                {
                    request.Total += lineC.Quantity * lineC.Product.Cost;
                }
                else if (lineD != null)
                {
                    request.Total += lineD.Quantity * lineD.Product.Cost;
                }

            }
            Console.WriteLine("No Items Added in Cart");
        }
    }
}
