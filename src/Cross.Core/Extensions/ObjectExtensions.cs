// <copyright file="ObjectExtensions.cs" company="Chris Trout">
// MIT License
//
// Copyright(c) 2019 Chris Trout
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
// </copyright>

namespace Cross.Core.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;

    /// <summary>
    /// Provides extension methods to the <see cref="object" /> class.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts a <typeparamref name="T"/> object into a <see cref="Dictionary{TKey,TValue}" />.
        /// </summary>
        /// <typeparam name="T">The type to be converted.</typeparam>
        /// <param name="source">The instance to be converted. </param>
        /// <returns>A dictionary containing the property values from <paramref name="source"/>.</returns>
        public static IDictionary<string, object> ToDictionary<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var results = new Dictionary<string, object>();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source.GetType()))
            {
                results.Add(property.Name.ToCamelCase(), property.GetValue(source));
            }

            return results;
        }

        /// <summary>
        /// Converts a <paramref name="source"/> into a dynamic object.
        /// </summary>
        /// <typeparam name="T">A type to convert.</typeparam>
        /// <param name="source">An instance of <typeparamref name="T"/> to be converted.</param>
        /// <returns>A dynamic object.</returns>
        public static dynamic ToDynamic<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            IDictionary<string, object> result = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source.GetType()))
            {
                result.Add(property.Name.ToCamelCase(), property.GetValue(source));
            }

            return result as ExpandoObject;
        }

        /// <summary>
        /// Converts a <paramref name="source"/> into a dynamic object.
        /// </summary>
        /// <typeparam name="T">A type to convert.</typeparam>
        /// <param name="source">An instance of <typeparamref name="T"/> to be converted.</param>
        /// <param name="expandedProperties">Additional properties to add to the dynamic object.</param>
        /// <returns>A dynamic object.</returns>
        public static dynamic ToDynamic<T>(this T source, IDictionary<string, object> expandedProperties)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (expandedProperties == null)
            {
                throw new ArgumentNullException(nameof(expandedProperties));
            }

            IDictionary<string, object> result = source.ToDynamic() as ExpandoObject;

            foreach (var key in expandedProperties.Keys)
            {
                result.Add(key.ToCamelCase(), expandedProperties[key]);
            }

            return result as ExpandoObject;
        }
    }
}
