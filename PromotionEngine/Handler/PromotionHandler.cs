using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Promotions
{
    public abstract class PromotionHandler
    {
        protected PromotionHandler NextPromotion;

        public void SetNextPromotion(PromotionHandler promotion)
        {
            this.NextPromotion = promotion;
        }
        public abstract void ApplyPromotion(Cart request);
    }
}
