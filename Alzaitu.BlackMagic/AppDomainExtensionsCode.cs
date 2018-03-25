using System;

namespace Alzaitu.BlackMagic
{
    public static partial class AppDomainExtensions
    {
        /// <summary>
        /// Gets the real value based on a key, 
        /// </summary>
        /// <typeparam name="T">The type of the value to get.</typeparam>
        /// <param name="domain">The AppDomain to get data from.</param>
        /// <param name="key">The key to use.</param>
        /// <param name="variable">The variable which will contain the result, should one be provided.</param>
        /// <returns>True if the result is valid, false otherwise.</returns>
        public static bool TryGetRealValue<T>(this AppDomain domain, string key, out T variable)
        {
            if (domain.GetData($"{key}_ref") is ObjectPlacement<T> placement)
            {
                try
                {
                    variable = placement.Value;
                }
                catch (SystemException)
                {
                    variable = default(T);
                    return false;
                }
                return true;
            }

            variable = default(T);
            return false;
        }

        /// <summary>
        /// Get a reference from an AppDomain's data and resolve it.
        /// </summary>
        /// <typeparam name="T">The type of referenced value.</typeparam>
        /// <param name="domain">The domain to get data from.</param>
        /// <param name="key">The key to use when searching for this item.</param>
        /// <returns>The resolved reference, if it was found.</returns>
        public static T GetRealValue<T>(this AppDomain domain, string key) where T : class =>
            ((ObjectPlacement<T>) domain.GetData($"{key}_ref"))?.Value;

        /// <summary>
        /// Place a reference to a value into an AppDomain's data.
        /// </summary>
        /// <typeparam name="T">The type of referenced value.</typeparam>
        /// <param name="domain">The domain to set data for.</param>
        /// <param name="key">The key to use when searching for this item.</param>
        /// <param name="value">The value to set this reference to.</param>
        public static void SetRealValue<T>(this AppDomain domain, string key, ref T value)
        {
            if (domain.GetData($"{key}_ref") is ObjectPlacement<T> placement)
            {
                try
                {
                    placement.Value = value;
                }
                catch (SystemException)
                {
                    domain.SetData($"{key}_ref", new ObjectPlacement<T>(ref value));
                }

                return;
            }

            domain.SetData($"{key}_ref", new ObjectPlacement<T>(ref value));
        }
            
    }
}
