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

            /*((IntPtr**) typeof(SuperClass).TypeHandle.Value.ToPointer())[10][4] = typeof(SomeOtherClass)
                .GetMethod(nameof(SomeOtherClass.SomeSortOfMethod)).MethodHandle.GetFunctionPointer();*/

            s.Test();
            test.Test();
        }
    }

    public class SuperClass
    {
        public SuperClass()
        {
            Console.WriteLine(".ctor SuperClass");
        }

        public virtual void Test()
        {
            Console.WriteLine(nameof(SuperClass));
        }

        public virtual void Final()
        {
            Console.WriteLine("Final SuperClass");
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class TestClass
    {
        public TestClass()
        {
            Console.WriteLine(".ctor TestClass");
        }

        public virtual void Test()
        {
            Console.WriteLine(nameof(TestClass));
        }
    }

    public class FinalClass : TestClass
    {
        public override void Test()
        {
            Console.WriteLine(nameof(FinalClass));
        }

        public virtual void Final()
        {
            Console.WriteLine("Final FinalClass");
        }
    }

    public class SomeOtherClass
    {
        public static void SomeSortOfMethod(TestClass obj)
        {
            Console.WriteLine("I'm not even part of this class!");
        }
    }
}                                  