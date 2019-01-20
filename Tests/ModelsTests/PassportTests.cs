using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class PassportTests : ObjectTests<Passport>
    {
        private class testClass : Passport { }
        protected override Passport getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void PassportIdTest()
        {
            canReadWrite(() => obj.PassportId, x => obj.PassportId = x);
            Assert.IsNotNull(obj.PassportId);
        }
        [TestMethod]
        public void FirstNameTest()
        {
            canReadWrite(() => obj.FirstName, x => obj.FirstName = x);
        }
        [TestMethod]
        public void LastNameTest()
        {
            canReadWrite(() => obj.LastName, x => obj.LastName = x);
        }
        [TestMethod]
        public void ValidFromTest()
        {
            DateTime rnd() => GetRandom.DateTime(null, obj.ValidTo.AddYears(-1));
            canReadWrite(() => obj.ValidFrom, x => obj.ValidFrom = x, rnd);
        }
        [TestMethod]
        public void ValidToTest()
        {
            DateTime rnd() => GetRandom.DateTime(obj.ValidFrom.AddYears(1));
            canReadWrite(() => obj.ValidTo, x => obj.ValidTo = x, rnd);
        }
        [TestMethod]
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
        }
        [TestMethod]
        public void PassportNumberTest()
        {
            canReadWrite(() => obj.PassportNumber, x => obj.PassportNumber = x);
        }
    }
}