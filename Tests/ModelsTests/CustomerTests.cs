using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Vancouver.Core;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class CustomerTests : ObjectTests<Customer>
    {
        private class testClass : Customer { }
        protected override Customer getRandomObject()
        {
            return GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void CustomerIdTest()
        {
            canReadWrite(() => obj.CustomerId, x => obj.CustomerId = x);
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
        public void EmailTest()
        {
            canReadWrite(() => obj.Email, x => obj.Email = x);
        }
        [TestMethod]
        public void PassportTest()
        {
            canReadWrite(() => obj.Passport, x => obj.Passport = x);
            obj.Passport = null;
            Assert.IsNull(obj.Passport);
        }
        [TestMethod]
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
        }
        [TestMethod]
        public void ApplicationUserIdTest()
        {
            canReadWrite(() => obj.ApplicationUserId, x => obj.ApplicationUserId = x);
        }

        [TestMethod]
        public void PrimaryTest()
        {
            
        }
    }
}
