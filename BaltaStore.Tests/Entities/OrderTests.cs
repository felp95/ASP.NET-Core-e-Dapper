using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Order _order;
        private readonly Product _mouse;
        private readonly Product _teclado;
        private readonly Product _fone;
        private readonly Product _monitor;
        private readonly Product _cadeira;

        public OrderTests()
        {
            var name = new Name("Felipe", "Portela");
            var document = new Document("10849737907");
            var email = new EmailAddress("felp95@gmail.com");
            var customer = new Customer(name, document, email, "987176812");
            _order = new Order(customer);
            _mouse = new Product("Mouse", "Mouse Gamer", "image.jpg", 100M, 10M);
            _teclado = new Product("Teclado", "Teclado Gamer", "image.jpg", 100M, 10M);
            _fone = new Product("Fone", "Fone Gamer", "image.jpg", 100M, 10M);
            _monitor = new Product("Monitor", "Monitor Gamer", "image.jpg", 100M, 10M);
            _cadeira = new Product("Cadeira", "Cadeira Gamer", "image.jpg", 100M, 10M);
        }

        [TestMethod]
        public void Deve_Criar_Um_Pedido_Quando_Ele_For_Valido()
        {
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void Quando_O_Pedido_For_Criado_O_Status_Deve_Ser_Created()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void Deve_Retornar_2_Quando_Adicionado_2_Itens_Validos()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        [TestMethod]
        public void Deve_Retornar_5_Quando_5_Produtos_Forem_Comprados()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityStock, 5);
        }

        [TestMethod]
        public void Deve_Retornar_Um_Numero_Quando_Um_Pedido_For_Gerado()
        {
            _order.Place();
            Assert.AreNotEqual(string.Empty, _order.Number);
        }

        [TestMethod]
        public void Deve_Retornar_Status_Pago_Quando_O_Pedido_For_Pago()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [TestMethod]
        public void Deve_Haver_2_Entregas_Quando_10_Pedidos_Forem_Comprados()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_cadeira, 1);
            _order.AddItem(_fone, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_cadeira, 1);
            _order.AddItem(_fone, 1);
            _order.AddItem(_teclado, 1);

            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);


        }

        [TestMethod]
        public void Deve_Retornar_O_Status_Canceled_Quando_Cancelarem_Um_Produto()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        [TestMethod]
        public void Deve_Cancelar_As_Entregas_Quando_Cancelarem_O_Pedido()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_cadeira, 1);
            _order.AddItem(_fone, 1);
            _order.AddItem(_teclado, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_cadeira, 1);
            _order.AddItem(_fone, 1);
            _order.AddItem(_teclado, 1);

            _order.Cancel();

            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}
