using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelBuddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Models.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void IsSamePasswordTest()
        {
            var password = "hashM3333";
            var user = new User();
            user.SetPassword(password);
            Assert.IsTrue(user.IsSamePassword(password));
        }

        [TestMethod()]
        public void TestEqualPasswordHash()
        {
            var password = "hashM3333";
            var user1 = new User();
            user1.SetPassword(password);
            var user2 = new User();
            user2.SetPassword(password);
            Assert.AreEqual(user1.GetPassword(), user2.GetPassword());
        }
    }
}