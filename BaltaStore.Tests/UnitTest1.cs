using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var address = new Address("Jeronimo de albuquerque maranhao", "S�o Braz", 125, "82300-720", "Curitiba", "Paran�", "Brasil");
            var customer = new Customer("Felipe", "Portela", "123", "teste@teste.com", "3333-3333", address);
            var order = new Order(customer);
        }
    }
}
