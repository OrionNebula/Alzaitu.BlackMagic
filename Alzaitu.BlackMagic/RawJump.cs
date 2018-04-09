using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Alzaitu.BlackMagic
{
    public unsafe class RawJump
    {
        public static void Jump()
        {
            var asm = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString("N")),
                AssemblyBuilderAccess.Run);
            var module = asm.DefineDynamicModule("<Module>");
            var type = module.DefineType(Guid.NewGuid().ToString("N"));
            var method = type.DefineMethod(Guid.NewGuid().ToString("N"),
                MethodAttributes.HideBySig | MethodAttributes.Public);
            method.GetILGenerator().Emit(OpCodes.Ret);

            var cType = type.CreateType();
        }
    }
}

