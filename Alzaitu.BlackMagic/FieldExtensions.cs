using System.Reflection;

namespace Alzaitu.BlackMagic
{
    internal static class FieldExtensions
    {
        public static string GetFieldSignature(this FieldInfo info) =>
            $"{info.Name}, {info.DeclaringType?.AssemblyQualifiedName ?? "<unknown>"}";
    }
}
