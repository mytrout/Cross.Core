// <copyright file="ArgumentWhiteSpaceExceptionTests.cs" company="Chris Trout">
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

namespace Cross.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [TestClass]
    public class ArgumentWhiteSpaceExceptionTests
    {
        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_All_Parameters()
        {
            // arrange
            var actualValue = new Uri("https://test.com");
            var innerException = new InvalidCastException();
            var message = "message";
            var paramName = "ParameterName";

            var expectedMessage = $"{message} (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, actualValue, message, innerException);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_Message_InnerException()
        {
            // arrange
            var actualValue = null as object;
            var innerException = new InvalidTimeZoneException();
            var message = "message";
            var paramName = null as string;

            // act
            var result = new ArgumentWhiteSpaceException(message, innerException);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_No_Parameters()
        {
            // arrange
            var actualValue = null as object;
            var innerException = null as Exception;
            var message = "Value does not fall within the expected range.";
            var paramName = null as string;

            // act
            var result = new ArgumentWhiteSpaceException();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_ParamName()
        {
            // arrange
            var actualValue = null as object;
            var innerException = null as Exception;
            var paramName = "ParameterName";
            var message = $"Value does not fall within the expected range. (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_ParamName_ActualValue()
        {
            // arrange
            var actualValue = new Uri("https://test.com");
            var innerException = null as Exception;
            var paramName = "ParameterName";
            var message = $"Value does not fall within the expected range. (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, actualValue);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_ParamName_ActualValue_Message()
        {
            // arrange
            var actualValue = new Uri("https://test.com");
            var innerException = null as Exception;
            var paramName = "ParameterName";
            var message = "message";

            var expectedMessage = $"{message} (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, actualValue, message);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_ParamName_ActualValue_InnerException()
        {
            // arrange
            var actualValue = new Uri("https://test.com");
            var innerException = new RankException();
            var paramName = "ParameterName";
            var message = $"Value does not fall within the expected range. (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, actualValue, innerException);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(message, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_With_ParamName_Message_InnerException()
        {
            // arrange
            var actualValue = null as object;
            var innerException = new DataMisalignedException();
            var message = "message";
            var paramName = "ParameterName";

            var expectedMessage = $"{message} (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, message, innerException);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Constructor_WIth_ParamName_Message()
        {
            // arrange
            var actualValue = null as object;
            var innerException = null as Exception;
            var message = "message";
            var paramName = "ParameterName";

            var expectedMessage = $"{message} (Parameter '{paramName}')";

            // act
            var result = new ArgumentWhiteSpaceException(paramName, message);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.AreEqual(innerException, result.InnerException);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Returns_Valid_ArgumentWhiteSpaceException_From_Serialization_Constructor()
        {
            // arrange
            var actualValue = new Uri("https://me.local");
            var innerException = new ArgumentNullException("NullParameterName");
            var message = "message";
            var paramName = "ParameterName";

            var expectedMessage = $"{message} (Parameter '{paramName}')";

            var source = new ArgumentWhiteSpaceException(paramName, actualValue, message, innerException);

            // act
            ArgumentWhiteSpaceException result = null;

            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                // "Save" object state
                formatter.Serialize(stream, source);

                // Re-use the same stream for de-serialization
                stream.Seek(0, 0);
                result = formatter.Deserialize(stream) as ArgumentWhiteSpaceException;
            }

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(actualValue, result.ActualValue);
            Assert.IsInstanceOfType(result.InnerException, innerException.GetType());
            Assert.AreEqual(innerException.Message, result.InnerException.Message);
            Assert.AreEqual(innerException.ParamName, (result.InnerException as ArgumentNullException).ParamName);
            Assert.AreEqual(expectedMessage, result.Message);
            Assert.AreEqual(paramName, result.ParamName);
        }

        [TestMethod]
        public void Throws_ArgumentNullException_From_GetObjectData_When_SerializationInfo_Parameter_Is_Null()
        {
            // arrange
            var actualValue = new Uri("https://me.local");
            var innerException = new ArgumentNullException("NullParameterName");
            var message = "message";
            var paramName = "ParameterName";

            var source = new ArgumentWhiteSpaceException(paramName, actualValue, message, innerException);

            var expectedParamName = "info";

            // act
            var result = Assert.ThrowsException<ArgumentNullException>(() => source.GetObjectData(null, default));

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedParamName, result.ParamName);
        }
    }
}
