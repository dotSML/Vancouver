using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vancouver.Aids;
using Vancouver.Models;

namespace Vancouver.Tests.ModelsTests
{
    [TestClass]
    public class ApplicationUserTests :ObjectTests<ApplicationUser>
    {
        private class testClass : ApplicationUser { }
        protected override ApplicationUser getRandomObject()
        {
            return GetRandom.Object<testClass>();
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
        public void DateOfBirthTest()
        {
            canReadWrite(() => obj.DateOfBirth, x => obj.DateOfBirth = x);
        }
        [TestMethod]
        public void UserPhotoTest()
        {
            canReadWrite(() => obj.UserPhoto, x => obj.UserPhoto = x);
        }
    }
}
