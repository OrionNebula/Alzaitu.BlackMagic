using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Alzaitu.BlackMagic.Tests
{
    [TestFixture]
    public class ObjectPlacementTests
    {
        private static Guid[] _array;

        [Test]
        public void TestGcSurvival()
        {
            var testString = Guid.NewGuid().ToString();

            var ptr = Marshal.AllocHGlobal(IntPtr.Size);

            var placement = new ObjectPlacement<string>(ptr) {Value = testString};

            for (var i = 0; i < 10; i++)
            {
                GC.KeepAlive(new byte[4096]);
                GC.Collect();
            }

            Assert.AreEqual(placement.Value, testString);

            Marshal.FreeHGlobal(ptr);
        }

        [Test]
        public void TestAppDomainMarshalling()
        {
            var domain = AppDomain.CreateDomain("TestCrossDomain", null, new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            });
            _array = Enumerable.Range(0, 100).Select(x => Guid.NewGuid()).ToArray();
            var placement = new ObjectPlacement<Guid[]>(Marshal.AllocHGlobal(100));
            placement.Value = _array;
            domain.SetData(nameof(_array), placement);
            domain.SetData(nameof(Guid), _array);
            domain.DoCallBack(AppDomainCallback);
        }

        private static void AppDomainCallback()
        {
            var domain = AppDomain.CurrentDomain;

            _array = (ObjectPlacement<Guid[]>)domain.GetData(nameof(_array));
            Assert.AreEqual((Guid[])domain.GetData(nameof(Guid)), _array, "Marshalled object was not the same.");
        }
    }
}
