using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_netcore.Domain.Validation
{
    /// <summary>
    /// Extension methods for argument validation
    /// </summary>
    public static class ArgumentValidation
    {
        /// <summary>
        /// Validates that the specified argument is of a specific type.
        /// </summary>
        /// <typeparam name="T">The requested type.</typeparam>
        /// <param name="obj">The argument to validate.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The argument itself.</returns>
        public static T ThrowIfNotOfType<T>(this object obj, string paramName) where T : class
        {
            T res = obj as T;
            if (res == null)
            {
                throw new ArgumentException("Value must be of type " + typeof(T).FullName, paramName);
            }

            return res;
        }

        /// <summary>
        /// Validates that the specified argument is not null.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="obj">The argument to validate.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The argument itself.</returns>
        public static T ThrowIfNull<T>(this T obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(paramName);
            }

            return obj;
        }

        /// <summary>
        /// Validates that the specified argument is not empty.
        /// </summary>
        /// <param name="obj">The argument to validate.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>The argument itself.</returns>
        /// <exception cref="System.ArgumentException">The string is empty.</exception>
        public static string ThrowIfEmpty(this string obj, string paramName)
        {
            obj.ThrowIfNull(paramName);

            if (string.IsNullOrEmpty(obj))
            {
                throw new ArgumentException("The string is empty.", paramName);
            }

            return obj;
        }
    }
}
