using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities

{
    public class Order : Notifiable
    {

        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public Order(Customer customer)
        {
            Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public override string ToString()
        {
            return $"{Customer.Name.ToString()} - {Number}";
        }

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityStock)
            {
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");
            }

            var item = new OrderItem(product, quantity);
            _items.Add(item);

        }

        public void AddDelivery(Delivery delivery)
        {
            //TODO criar validação para a entrega
            //TODO Adicionar a entrega
            _deliveries.Add(delivery);
        }

        public void Place()
        {
            //Gerar numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (!_items.Any())
            {
                AddNotification("Order", "Este pedido não possui itens.");
            }
        }

        public void Pay()
        {
            //TODO Criar validações
            Status = EOrderStatus.Paid;
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            _deliveries.Add(delivery);
        }

        public void Ship()
        {
            //A cada 5 produtos é uma nova entrega
            var deliveries = new List<Delivery>();
            var count = 1;

            //Quebra as entregas
            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());

            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}
