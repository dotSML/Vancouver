using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class TicketTests : ObjectTests<Ticket>
    {
        private class testClass : Ticket { }
        protected override Ticket getRandomObject()
        {
            return new Ticket
            {
                Customer = new Customer { ApplicationUserId = "test" },
                Order = new Order { Id = "OrderTest" },
                TicketId = "ticketId"
            };
        }
        [TestMethod]
        public void TicketIdTest()
        {
            canReadWrite(() => obj.TicketId, x => obj.TicketId = x);
        }
        [TestMethod]
        public void OrderTest()
        {
            Ticket testTicket = getRandomObject();
            Assert.AreEqual(testTicket.Order.Id, "OrderTest");
        }
        [TestMethod]
        public void CustomerTest()
        {
            canReadWrite(() => obj.Customer, x => obj.Customer = x);
        }
    }
}