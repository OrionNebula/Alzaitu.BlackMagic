using System;
using System.Runtime.InteropServices;

namespace Alzaitu.BlackMagic.Playground
{
    public unsafe class Program
    {
        public static void Main(string[] args)
        {
            var test = new TestClass();
            var r = new FakeTypedReference(__makeref(test));
            var ptr = (IntPtr*)Marshal.ReadIntPtr(r.Value).ToPointer();
            ptr[0] = typeof(SuperClass).TypeHandle.Value;
            var s = new FakeTypedReference(r.Value, typeof(SuperClass)).GetValue<SuperClass>();
            s.Test();
            test.Test();
        }
    }

    public class SuperClass
    {
        public string var = "SOME STRING";
        public int test = 0x1234;

        public virtual void Test()
        {
            Console.WriteLine("No override");
        }
    }

    public class TestClass
    {
        public string var = "SOME STRING";
        public int test = 0x1234;

        public virtual void Test()
        {
            Console.WriteLine("Override");
        }
    }
}                                  