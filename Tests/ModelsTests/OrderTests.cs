using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class OrderTests : ObjectTests<Order>
    {
        private class testClass : Order { }
        protected override Order getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IdTest()
        {
            //canReadWrite(() => obj.Id, x => obj.Id = x);
            //Assert.IsNotNull(obj.Id);
        }
        [TestMethod]
        public void BookingReferenceTest()
        {
            //canReadWrite(() => obj.BookingReference, x => obj.BookingReference = x);
        }
        [TestMethod]
        public void OrderItineraryTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void TicketsTest()
        {
            Assert.Inconclusive();
        }
    }
}