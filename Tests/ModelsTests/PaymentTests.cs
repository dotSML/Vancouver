using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.FlightsFolder;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class PaymentTests : ObjectTests<Payment>
    {
        private class testClass : Payment { }
        protected override Payment getRandomObject()
        {
            return new Payment
            {
                BankLink = new BankLink { Id = -2 },
                Customer = new Customer() { CustomerId = "testCustomer" },
                Payee = "testCustomer",
                PaymentId = 0,
                PaymentMethod = new PaymentMethod(),
                Ticket = new ItineraryObject() { Id = "TicketId" },
                TotalPrice = "totalPrice"
            };
        }

        [TestMethod]
        public void PaymentIdTest()
        {
            canReadWrite(() => obj.PaymentId, x => obj.PaymentId = x);
        }
        [TestMethod]
        public void PaymentMethodTest()
        {
            canReadWrite(() => obj.PaymentMethod, x => obj.PaymentMethod = x);

        }
        [TestMethod]
        public void TicketTest()
        {
            Payment payment = getRandomObject();
            Assert.IsNotNull(payment.Ticket);
            Assert.AreEqual(payment.Ticket.Id, "TicketId");
        }
        [TestMethod]
        public void BankLinkTest()
        {
            Payment payment = getRandomObject();
            Assert.AreEqual(payment.BankLink.Id, -2);
        }
        [TestMethod]
        public void TotalPriceTest()
        {
            Payment payment = getRandomObject();
        }
        [TestMethod]
        public void CustomerTest()
        {
            canReadWrite(() => obj.Customer, x => obj.Customer = x);
        }
        [TestMethod]
        public void PayeeTest()
        {
            canReadWrite(() => obj.Payee, x => obj.Payee = x);
        }
    }
}