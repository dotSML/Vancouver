using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class PaymentTests : ObjectTests<Payment>
    {
        private class testClass : Payment { }
        protected override Payment getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        
        [TestMethod]
        public void PaymentIdTest()
        {
            canReadWrite(() => obj.PaymentId, x => obj.PaymentId = x);
            Assert.IsNotNull(obj.PaymentId);
        }
        [TestMethod]
        public void PaymentMethodTest()
        {
            canReadWrite(() => obj.PaymentMethod, x => obj.PaymentMethod = x);
        }
        [TestMethod]
        public void TicketTest()
        {
            canReadWrite(() => obj.Ticket, x => obj.Ticket = x);
        }
        [TestMethod]
        public void BankLinkTest()
        {
            canReadWrite(() => obj.BankLink, x => obj.BankLink = x);
        }
        [TestMethod]
        public void TotalPriceTest()
        {
            canReadWrite(() => obj.TotalPrice, x => obj.TotalPrice = x);
        }
        [TestMethod]
        public void CustomerTest()
        {
            canReadWrite(() => obj.Customer, x => obj.Customer = x);
        }
        [TestMethod]
        public void PayeeIDTest()
        {
            canReadWrite(() => obj.Payee, x => obj.Payee = x);
        }
    }
}