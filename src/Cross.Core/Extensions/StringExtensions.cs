// <copyright file="StringExtensions.cs" company="Chris Trout">
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
    using System.IO;
    using System.Text;

    /// <summary>
    /// Provides extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts an <paramref name="input"/> string to a camel cased version.
        /// </summary>
        /// <param name="input">string to be converted.</param>
        /// <returns>A camel case string.</returns>
        public static string ToCamelCase(this string input)
        {
            string result = input;

            if (!string.IsNullOrEmpty(input) && input.Length > 1)
            {
                result = char.ToLowerInvariant(input[0]) + input.Substring(1);
            }

            return result;
        }

        /// <summary>
        /// Writes the <paramref name="input"/> into the <paramref name="fileName"/> located in <paramref name="directory"/>.
        /// </summary>
        /// <param name="input">the contents of the file.</param>
        /// <param name="directory">the directory where the file will be located.</param>
        /// <param name="fileName">the fileName in which the <paramref name="input"/> will be written.</param>
        /// <remarks>
        /// <para>This method will always emit files as <see cref="Encoding.UTF8"/> with byte-order marking enabled.</para>
        /// </remarks>
        public static void WriteToFile(this string input, string directory, string fileName)
        {
            WriteToFile(input, directory, fileName, null);
        }

        /// <summary>
        /// Writes the <paramref name="input"/> into the <paramref name="fileName"/> located in <paramref name="directory"/> in the specified <paramref name="encoding"/>.
        /// </summary>
        /// <param name="input">the contents of the file.</param>
        /// <param name="directory">the directory where the file will be located.</param>
        /// <param name="fileName">the fileName in which the <paramref name="input"/> will be written.</param>
        /// <param name="encoding">The encoding in which to write the file.</param>
        /// <remarks>
        /// <paramref name="encoding"/> will default to <see cref="Encoding.UTF8"/> with byte-order mark enabled, if this parameter is <see langword="null" />.
        /// </remarks>
        private static void WriteToFile(string input, string directory, string fileName, Encoding encoding)
        {
            if (encoding == null)
            {
                // Do not change this default without altering the non-encoding version of this method to force this default.
                encoding = new UTF8Encoding(true);
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string fileLocation = Path.Combine(directory, fileName);

            File.WriteAllText(fileLocation, input, encoding);
        }
    }
}
