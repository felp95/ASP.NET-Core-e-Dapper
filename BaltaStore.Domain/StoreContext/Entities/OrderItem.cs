using FluentValidator;
using System.Collections;
using System.Collections.Generic;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities

{
    public class OrderItem : Entity
    {
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        public IDictionary<string, string> Notifications { get; set; }

        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityStock < quantity)
            {
                AddNotification("Produto", "Fora de estoque");
            }

            product.DecreaseQuantity(quantity);
        }

        public override string ToString()
        {
            return $"{Product.Description} - {Quantity}";
        }
    }
}
