using PromotionEngine.Models;
using PromotionEngine.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Processors
{
    public class CartProcessor
    {
        private readonly IProductRepository _productRepository;
        private Cart _cart;
        public CartProcessor(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Cart GetCart()
        {
            if (_cart == null)
            {
                _cart = new Cart();
                return _cart;
            }
            return _cart;
        }

        public Cart AddCartLine(string sku, int quantity)
        {
            var product = _productRepository.FindProduct(sku);
            CartLine cartLine = null;
            if (product != null)
            {
                cartLine = _cart.Lines.Where(x => x.Product.SKU == sku).FirstOrDefault();
                if (cartLine == null)
                {
                    _cart.Lines.Add(new CartLine
                    {
                        Id = System.Guid.NewGuid().ToString(),
                        Product = product,
                        Quantity = quantity,
                        Price = quantity * product.Cost
                    });
                }
                else
                {
                    cartLine.Quantity += quantity;
                    cartLine.Price += cartLine.Quantity + product.Cost;
                }
            }
            return _cart;
        }
    }
}
