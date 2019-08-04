// <copyright file="DictionaryExtensions.cs" company="Chris Trout">
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
    using System.Dynamic;

    /// <summary>
    /// Provides extensions to the <see cref="IDictionary{TKey,TValue}" /> classes.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts the <see cref="IDictionary{TKey,TValue}" /> into a dynamic object.
        /// </summary>
        /// <param name="source">The dictionary to be converted.</param>
        /// <returns>A dynamic object.</returns>
        public static dynamic ToDynamicObject(this IDictionary<string, object> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            IDictionary<string, object> expando = new ExpandoObject();

            foreach (var key in source.Keys)
            {
                expando.Add(key.ToCamelCase(), source[key]);
            }

            return expando as ExpandoObject;
        }
    }
}
