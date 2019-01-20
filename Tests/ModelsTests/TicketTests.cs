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
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void TicketIdTest()
        {
            canReadWrite(() => obj.TicketId, x => obj.TicketId = x);
            Assert.IsNotNull(obj.TicketId);
        }
        [TestMethod]
        public void OrderTest()
        {
            canReadWrite(() => obj.Order, x => obj.Order = x);
        }
        [TestMethod]
        public void CustomerTest()
        {
            canReadWrite(() => obj.Customer, x => obj.Customer = x);
        }
    }
}