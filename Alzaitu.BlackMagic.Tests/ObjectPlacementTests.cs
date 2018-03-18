using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var guid = new Dictionary<string, string>(Enumerable.Range(0, 100).Select(x => Guid.NewGuid().ToString()).ToDictionary(x => x, x => x));
            var callback = domain.CreateDelegate<Dictionary<string, string>, string>(AppDomainCallback);
            Assert.AreEqual(string.Join(", ", guid.Select(x => x.Key.ToString())), callback(guid));
        }

        private static string AppDomainCallback(Dictionary<string, string> guid)
        {
            Debug.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            return string.Join(", ", guid.Select(x => x.Key.ToString()));
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
