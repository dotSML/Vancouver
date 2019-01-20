using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class OrderTests : ObjectTests<Order>
    {
        private class testClass : Order { }
        protected override Order getRandomObject()
        {

            List<Ticket> ticketList = new List<Ticket>();
            return new Order
            {
                BookingReference = "test",
                Id = "testId",
                Tickets = ticketList,
                OrderItinerary = new FlightsFolder.ItineraryObject()
            };
        }
        [TestMethod]
        public void IdTest()
        {
            canReadWrite(() => obj.Id, x => obj.Id = x);
        }
        [TestMethod]
        public void BookingReferenceTest()
        {
            canReadWrite(() => obj.BookingReference, x => obj.BookingReference = x);
        }
        [TestMethod]
        public void OrderItineraryTest()
        {
            Order testOrder = getRandomObject();
            testOrder.OrderItinerary.Id = "testId";
            Assert.AreEqual(testOrder.OrderItinerary.Id, "testId");
        }
        [TestMethod]
        public void TicketsTest()
        {
            Order testOrder = getRandomObject();

            testOrder.Tickets.Add(new Ticket
            {
                Customer = new Customer(),
                Order = new Order()
            });
            Assert.AreEqual(testOrder.Tickets.Count, 1);
        }
    }
}