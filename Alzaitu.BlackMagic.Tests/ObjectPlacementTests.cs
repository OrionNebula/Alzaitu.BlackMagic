using NUnit.Framework;
using System;
using System.Linq;

namespace Alzaitu.BlackMagic.Tests
{
    [TestFixture]
    public class ObjectPlacementTests
    {
        private static Guid[] _array;

        [Test]
        public void TestAppDomainCallbacks()
        {
            var domain = AppDomain.CreateDomain("TestCrossDomain", null, new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            });
            var guid = Guid.NewGuid();
            var callback = domain.CreateDelegate<string, Guid>(AppDomainCallback);
            Assert.AreEqual(guid.ToString(), callback(guid));
        }

        private static string AppDomainCallback(Guid guid)
        {
            return guid.ToString();
        }

        [Test]
        public void TestAppDomainMarshalling()
        {
            var domain = AppDomain.CreateDomain("TestCrossDomain", null, new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            });
            _array = Enumerable.Range(0, 100).Select(x => Guid.NewGuid()).ToArray();
            var placement = new ObjectPlacement<Guid[]>(ref _array);
            //placement.Value = _array;
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
