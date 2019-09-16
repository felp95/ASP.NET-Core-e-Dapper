using System;
using System.Collections.Generic;
using System.Text;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void DeveValidarQuandoComandoEValido()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Felipe",
                LastName = "Portela",
                Document = "10849737907",
                Email = "felp95@gmail.com",
                Phone = "41987176812"
            };

            Assert.AreEqual(true, command.Valid());
        }
    }
}
