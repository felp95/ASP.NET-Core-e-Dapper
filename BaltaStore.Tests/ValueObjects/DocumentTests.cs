using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests
{
    [TestClass]
    public class DocumentTests
    {

        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            _invalidDocument = new Document("12345678911");
            _validDocument = new Document("10849737907");
        }

        [TestMethod]
        public void Deve_Retornar_Notificacao_Quando_Documento_Nao_E_Valido()
        {
            Assert.AreEqual(false, _invalidDocument.Valid);
            Assert.AreEqual(1, _invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void Nao_Deve_Retornar_Notificacao_Quando_Documento_E_Valido()
        {
            Assert.AreEqual(true, _validDocument.Valid);
            Assert.AreEqual(0, _validDocument.Notifications.Count);

        }
    }
}
