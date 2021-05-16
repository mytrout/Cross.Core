// <copyright file="StringExtensionsTests.cs" company="Chris Trout">
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

namespace Cross.Core.Extensions.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void Returns_Camel_Case_String_From_ToCamelCase_When_Input_Is_Proper_Cased_String()
        {
            // arrange
            var input = "InputMessage";

            var expectedResult = "inputMessage";

            // act
            var result = StringExtensions.ToCamelCase(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Returns_Empty_String_From_ToCamelCase_When_Input_Is_Empty_String()
        {
            // arrange
            var input = string.Empty;

            var expectedResult = string.Empty;

            // act
            var result = StringExtensions.ToCamelCase(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Returns_Null_From_ToCamelCase_When_Input_Is_Null()
        {
            // arrange
            var input = null as string;

            var expectedResult = null as string;

            // act
            var result = StringExtensions.ToCamelCase(input);

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Writes_A_File_From_WriteToFile_When_All_Parameters_Are_Provided()
        {
            // assert
            Guid newGuid = Guid.NewGuid();
            string input = "input";

            string directory = $"C:/{newGuid}";
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                directory = "/net-testing";
            }

            string fileName = $"{newGuid}.txt";

            try
            {
                StringExtensions.WriteToFile(input, directory, fileName);

                string result = File.ReadAllText($"{directory}/{fileName}");
                Assert.AreEqual(input, result);
            }
            finally
            {
                Directory.Delete($"{directory}/", true);
            }
        }
    }
}
