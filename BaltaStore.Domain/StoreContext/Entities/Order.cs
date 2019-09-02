using BaltaStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaltaStore.Domain.StoreContext.Entities

{
    public class Order
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
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public override string ToString()
        {
            return $"{Customer.Name.ToString()} - {Number}";
        }

        public void AddItem(OrderItem orderItem)
        {
            //TODO criar validação para o pedido 
            //TODO Adicionar o pedido
            _items.Add(orderItem);
        }

        public void AddDelivery(Delivery delivery)
        {
            //TODO criar validação para a entrega
            //TODO Adicionar a entrega
            _deliveries.Add(delivery);
        }

        public void Place()
        {
        }


    }
}
