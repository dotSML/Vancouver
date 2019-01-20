using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class PaymentMethodTests : ObjectTests<PaymentMethod>
    {
        private class testClass : PaymentMethod { }
        protected override PaymentMethod getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void PaymentMethodIdTest()
        {
            canReadWrite(() => obj.PaymentMethodId, x => obj.PaymentMethodId = x);
            Assert.IsNotNull(obj.PaymentMethodId);
        }
        [TestMethod]
        public void BankLinkTest()
        {
            canReadWrite(() => obj.BankLink, x => obj.BankLink = x);
        }
    }
}