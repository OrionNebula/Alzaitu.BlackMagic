using System;
using System.Linq.Expressions;

namespace Alzaitu.BlackMagic.Example
{
    public class TestClass
    {
        public string TestProp;
    }

    public class Program
    {
        public static TestClass A = ObjectPlacement.GetOrCreate(() => A, ref A, () => new TestClass());

        public static void Main(string[] args)
        {
            A.TestProp = Guid.NewGuid().ToString();

            var domain = AppDomain.CreateDomain("TestDomain", null, new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            });
            domain.Load(typeof(Program).Assembly.GetName());
            ObjectPlacement.WrapDomain(domain);
            Console.WriteLine(A.TestProp);
            domain.DoCallBack(() =>
            {
                Console.WriteLine(A.TestProp);
            });
            A.TestProp = Guid.NewGuid().ToString();
            Console.WriteLine(A.TestProp);
            domain.DoCallBack(() =>
            {
                Console.WriteLine(A.TestProp);
            });
            AppDomain.Unload(domain);
            Console.ReadLine();
        }
    }
}
