using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        private Name _validName;
        private Name _invalidName;
        public NameTests()
        {
            _validName = new Name("Felipe", "Portela");
            _invalidName = new Name("Fe", "");
        }

        [TestMethod]
        public void Deve_Retornar_Uma_Notificacao_Quando_Nome_E_Invalido()
        {
            Assert.AreEqual(false, _invalidName.Valid);
            Assert.AreEqual(2, _invalidName.Notifications.Count);
        }

        [TestMethod]
        public void Nao_Deve_Retornar_Uma_Notificacao_Quando_Nome_E_Valido()
        {
            Assert.AreEqual(true, _validName.Valid);
            Assert.AreEqual(0, _validName.Notifications.Count);
        }
    }
}
