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
    }
}