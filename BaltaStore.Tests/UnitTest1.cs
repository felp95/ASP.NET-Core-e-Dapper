using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Customer
            var name = new Name("Felipe", "Portela");
            var document = new Document("12345678911");
            var email = new EmailAddress("felipe@teste.com");
            var customer = new Customer(name, document, email, "33333333");

            //Products
            var mouse = new Product("Mouse", "Rato", "image.png", 59.9M, 10M);

            //Order
            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));

            //Realizar o pedido
            order.Place();

            //Simular pagamento
            order.Pay();

            //Simular o envio
            order.Ship();

            //Simular cancelamento
            order.Cancel();
        }
    }
}
