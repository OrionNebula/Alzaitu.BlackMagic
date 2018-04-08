using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Alzaitu.BlackMagic.Playground
{
    public unsafe class Program
    {
        public static void Main(string[] args)
        {
            var test = new TestClass();
            var test2 = new TestClass();
            var r = new FakeTypedReference(__makeref(test));
            var ptr = (IntPtr*)Marshal.ReadIntPtr(r.Value).ToPointer();
            r = new FakeTypedReference(__makeref(test2));
            ptr = (IntPtr*) Marshal.ReadIntPtr(r.Value).ToPointer();
        }
    }

    public class SuperClass
    {
        public virtual void Test()
        {
            Console.WriteLine("No override");
        }
    }

    public class TestClass : SuperClass
    {
        private string _var = "SOME STRING";
        private int _test = 0x1234;
        public override void Test()
        {
            Console.WriteLine("Override");
        }
    }
}
