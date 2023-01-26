using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class DynamicSlowCaseTests
    {
        [TestMethod()]
        public void ReturnStringValueTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnStringValue());
        }

        [TestMethod()]
        public void ReturnDynamicValueTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnDynamicValue());
        }

        [TestMethod()]
        public void ReturnStringValueCallTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnStringValueCall());
        }

        [TestMethod()]
        public void ReturnDynamicValueCallTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnDynamicValueCall());
        }

        [TestMethod()]
        public void ReturnDynamicValueCallWithCastTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreSame("Hello World", obj.ReturnDynamicValueCallWithCast());
        }

        [TestMethod()]
        public void ReturnDynamicValueCallWithCastAndIsTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnDynamicValueCallWithCastAndIs());
        }

        [TestMethod()]
        public void ReturnDynamicValueCallWithCastAndAsTest()
        {
            var obj = new DynamicSlowCase();
            Assert.AreEqual("Hello World", obj.ReturnDynamicValueCallWithCastAndAs());
        }
    }
}