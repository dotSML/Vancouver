using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class BankLinkTests : ObjectTests<BankLink>
    {
        private class testClass : BankLink { }
        protected override BankLink getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void IdTest()
        {
            canReadWrite(() => obj.Id, x => obj.Id = x);
            Assert.IsNotNull(obj.Id);
        }
    }
}