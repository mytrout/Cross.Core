// <copyright file="ObjectExtensionsTests.cs" company="Chris Trout">
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
    using Cross.Core.Tests;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class ObjectExtensionsTests
    {
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        [TestMethod]
        public void Returns_Dictionary_Object_From_ToDictionary_When_Source_Is_Provided()
        {
            // arrange
            var source = new SampleClass1();

            // act
            var result = source.ToDictionary();

            // assert
            Assert.IsInstanceOfType(result, typeof(IDictionary<string, object>));
            Assert.AreEqual(source.Id, result["id"]);
            Assert.AreEqual(source.Description, result["description"]);
            Assert.AreEqual(source.Count, result["count"]);
        }

        [TestMethod]
        public void Returns_Dynamic_Object_From_ToDynamic_When_Source_Is_Provided()
        {
            // arrange
            var source = new SampleClass1();

            // act
            dynamic result = source.ToDynamic();

            // assert
            Assert.IsInstanceOfType(result, typeof(ExpandoObject));
            Assert.AreEqual(source.Id, result.id);
            Assert.AreEqual(source.Description, result.description);
            Assert.AreEqual(source.Count, result.count);
        }

        [TestMethod]
        public void Returns_Dynamic_Object_From_ToDynamic_When_ExpandedProperties_Is_Provided()
        {
            // arrange
            var source = new SampleClass1();
            int myRightFace = 12;
            var expandedProperties = new Dictionary<string, object>() { { "MyRightFace", myRightFace } };

            // act
            dynamic result = source.ToDynamic(expandedProperties);

            // assert
            Assert.IsInstanceOfType(result, typeof(ExpandoObject));
            Assert.AreEqual(source.Id, result.id);
            Assert.AreEqual(source.Count, result.count);
            Assert.AreEqual(source.Description, result.description);
            Assert.AreEqual(myRightFace, result.myRightFace);
        }

        [TestMethod]
        public void Throws_ArgumentNullException_From_ToDictionary_When_Source_Is_Null()
        {
            var source = null as IDictionary<string, object>;
            var expectedParamName = "source";

            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => ObjectExtensions.ToDictionary(source));

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedParamName, result.ParamName);
        }

        [TestMethod]
        public void Throws_ArgumentNullException_From_ToDynamic_When_Source_Is_Null()
        {
            var source = null as SampleClass1;
            var expectedParamName = "source";

            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => ObjectExtensions.ToDynamic(source));

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedParamName, result.ParamName);
        }

        [TestMethod]
        public void Throws_ArgumentNullException_From_ToDynamic_With_ExpandedProperties_When_Source_Is_Null()
        {
            var source = null as object;
            int myRightFace = 12;
            var expectedParamName = "source";
            var expandedProperties = new Dictionary<string, object>() { { "MyRightFace", myRightFace } };

            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => ObjectExtensions.ToDynamic(source, expandedProperties));

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedParamName, result.ParamName);
        }

        [TestMethod]
        public void Throws_ArgumentNullException_From_ToDynamic_With_ExpandedProperties_When_ExpandedProperties_Is_Null()
        {
            var source = new SampleClass1();
            var expectedParamName = "expandedProperties";
            var expandedProperties = null as IDictionary<string, object>;

            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => ObjectExtensions.ToDynamic(source, expandedProperties));

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedParamName, result.ParamName);
        }
    }
}
