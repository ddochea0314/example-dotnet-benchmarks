using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class BetterStopwatchCreateTests
    {
        [TestMethod()]
        public async Task CreateStopWatch_UsingNewKeywoardTest()
        {
            var obj = new BetterStopwatchCreate();
            var actual = await obj.CreateStopWatch_UsingNewKeywoard();
            Assert.AreEqual(100, actual, delta: 10.0, message: $"{actual}");
        }

        [TestMethod()]
        public async Task CreateStopWatch_StartNewTest()
        {
            var obj = new BetterStopwatchCreate();
            var actual = await obj.CreateStopWatch_StartNew();
            Assert.AreEqual(100, actual, delta: 10.0, message: $"{actual}");
        }
    }
}