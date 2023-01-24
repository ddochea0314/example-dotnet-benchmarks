using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class BetterDictionaryUpdateTests
    {

        [TestMethod()]
        public void UpdateUserClassTest()
        {
            var obj = new BetterDictionaryUpdate();
            obj.UpdateUserClass();
            Assert.IsTrue(obj._clsUser.GetValueOrDefault(obj._id)?.Name == "Tom");
        }

        [TestMethod()]
        public void UpdateUserClass_UnsafeTest()
        {
            var obj = new BetterDictionaryUpdate();
            obj.UpdateUserClass_Unsafe();
            Assert.IsTrue(obj._clsUser.GetValueOrDefault(obj._id)?.Name == "Tom");
        }

        [TestMethod()]
        public void UpdateUserStructTest()
        {
            var obj = new BetterDictionaryUpdate();
            obj.UpdateUserStruct();
            Assert.IsTrue(obj._structUser.GetValueOrDefault(obj._id).Name == "Tom");
        }

        [TestMethod()]
        public void UpdateUserStruct_UnsafeTest()
        {
            var obj = new BetterDictionaryUpdate();
            obj.UpdateUserStruct_Unsafe();
            Assert.IsTrue(obj._structUser.GetValueOrDefault(obj._id).Name == "Tom");
        }
    }
}