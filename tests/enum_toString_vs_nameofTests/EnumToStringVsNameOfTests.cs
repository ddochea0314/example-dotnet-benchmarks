using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class EnumToStringVsNameOfTests
    {
        [TestMethod()]
        public void EnumToStringTest()
        {
            var obj = new EnumToStringVsNameOf();
            Assert.AreEqual("One", obj.EnumToString());
        }

        [TestMethod()]
        public void NameOfTest()
        {
            var obj = new EnumToStringVsNameOf();
            Assert.AreEqual("One", obj.NameOf());
        }
    }
}