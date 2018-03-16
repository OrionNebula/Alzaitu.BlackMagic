using System;
using System.IO;
using System.Text;

namespace Alzaitu.BlackMagic.Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var domain = AppDomain.CreateDomain("TestDomain", null, new AppDomainSetup
            {
                ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
            });
            var stream = new MemoryStream();

            Console.WriteLine(domain.DoCallBack(AppDomainCallback, stream));
        }

        private static string AppDomainCallback(MemoryStream stream)
        {
            var b = new byte[1024];
            new Random().NextBytes(b);
            stream.Write(b, 0, 1024);
            return Encoding.ASCII.GetString(b);
        }
    }
}
