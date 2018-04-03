using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqLibrary;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertTest()
        {
            UserData c = new UserData();
            c.Insert();
            Assert.IsTrue(true);
        }
    }
}
