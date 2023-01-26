using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class CountVsAnyTests
    {
        [TestMethod()]
        public void IsExistsUseCountTest()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsExistsUseCount());
        }

        [TestMethod()]
        public void IsExistsUseAnyTest()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsExistsUseAny());
        }

        [TestMethod()]
        public void IsItem100ExistsCount1Test()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsItem100ExistsCount1());
        }

        [TestMethod()]
        public void IsItem100ExistsCount2Test()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsItem100ExistsCount2());
        }

        [TestMethod()]
        public void IsItem100ExistsAny1Test()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsItem100ExistsAny1());
        }

        [TestMethod()]
        public void IsItem100ExistsAny2Test()
        {
            var obj = new CountVsAny();
            Assert.IsTrue(obj.IsItem100ExistsAny2());
        }
    }
}