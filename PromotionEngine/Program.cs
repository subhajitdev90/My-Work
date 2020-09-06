using PromotionEngine.Handler;
using PromotionEngine.Models;
using PromotionEngine.Processors;
using PromotionEngine.Promotions;
using PromotionEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            //create the cart
            var cartProcessor = new CartProcessor(new ProductRepository());
            var currentCart = cartProcessor.GetCart();

            PromotionHandler promo1 = new PromotionOnAHandler();
            PromotionHandler promo2 = new PromotionOnBHandler();
            PromotionHandler promo3 = new PromotionOnCandDHandler();
            promo1.SetNextPromotion(promo2);
            promo2.SetNextPromotion(promo3);

            while (true)
            {
                Console.WriteLine("Enter Product Name");
                var productSKU = Console.ReadLine();

                Console.WriteLine("Enter Product Qunatity");
                var quantity = Console.ReadLine();

                var productQuantity = 0;
                int.TryParse(quantity, out productQuantity);
                if (productQuantity > 0)
                {
                    cartProcessor.AddCartLine(productSKU, productQuantity);
                }
                else
                {
                    Console.WriteLine("Enter valid values");
                }
                promo1.ApplyPromotion(currentCart);
                Console.WriteLine($"Cart Total: {currentCart.Total}");
            }
        }
    }
}
