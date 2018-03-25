using System;

namespace Alzaitu.BlackMagic
{
    public static partial class AppDomainExtensions
    {
        public static T GetRealValue<T>(this AppDomain domain, string key) where T : class =>
            ((ObjectPlacement<T>) domain.GetData($"{key}_ref"))?.Value;

        public static void SetRealValue<T>(this AppDomain domain, string key, ref T value) =>
            domain.SetData($"{key}_ref", new ObjectPlacement<T>(ref value));
    }
}
