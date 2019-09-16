using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void DeveRegistrarCustomerQuandoComandoEValido()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Felipe",
                LastName = "Portela",
                Document = "10849737907",
                Email = "felp95@gmail.com",
                Phone = "41987176812"
            };

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.Valid);
        }
    }
}
