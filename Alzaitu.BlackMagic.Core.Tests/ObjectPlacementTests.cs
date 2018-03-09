using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alzaitu.BlackMagic.Core.Tests
{
    [TestClass]
    public class ObjectPlacementTests
    {
        [TestMethod]
        public void TestGcSurvival()
        {
            var testString = Guid.NewGuid().ToString();

            var ptr = Marshal.AllocHGlobal(IntPtr.Size);

            var placement = new ObjectPlacement<string>(ptr) { Value = testString };

            for (var i = 0; i < 10; i++)
            {
                GC.KeepAlive(new byte[4096]);
                GC.Collect();
            }

            Assert.AreEqual(placement.Value, testString);

            Marshal.FreeHGlobal(ptr);
        }

    }
}
