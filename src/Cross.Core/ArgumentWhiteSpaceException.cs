// <copyright file="ArgumentWhiteSpaceException.cs" company="Chris Trout">
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

namespace Cross.Core
{
    using System;

    /// <summary>
    /// Provides an <see cref="ArgumentException"/> for arguments that are whitespace.
    /// </summary>
    public sealed class ArgumentWhiteSpaceException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class.
        /// </summary>
        public ArgumentWhiteSpaceException()
            : base()
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the parameter name.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        public ArgumentWhiteSpaceException(string paramName)
            : this(paramName, null, null, null)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the parameter name and actual value.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="actualValue">the runtime value of the parameter.</param>
        public ArgumentWhiteSpaceException(string paramName, object actualValue)
            : this(paramName, actualValue, null, null)
        {
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the parameter name and message.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="message">the message in the exception.</param>
        public ArgumentWhiteSpaceException(string paramName, string message)
            : this(paramName, null, message, null)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the parameter name, actual value and message.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="actualValue">the runtime value of the parameter.</param>
        /// <param name="message">the message in the exception.</param>
        public ArgumentWhiteSpaceException(string paramName, object actualValue, string message)
            : this(paramName, actualValue, message, null)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the message and inner exception.
        /// </summary>
        /// <param name="message">the message in the exception.</param>
        /// <param name="innerException">the <see cref="Exception"/> that caused this exception.</param>
        public ArgumentWhiteSpaceException(string message, Exception innerException)
            : this(null, null, message, innerException)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the parameter name, actual value and the inner exception.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="actualValue">the runtime value of the parameter.</param>
        /// <param name="innerException">the <see cref="Exception"/> that caused this exception.</param>
        public ArgumentWhiteSpaceException(string paramName, object actualValue, Exception innerException)
            : this(paramName, actualValue, null, innerException)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the specified parameters.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="message">the message in the exception.</param>
        /// <param name="innerException">the <see cref="Exception"/> that caused this exception.</param>
        public ArgumentWhiteSpaceException(string paramName, string message, Exception innerException)
            : this(paramName, null, message, innerException)
        {
            // no op
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentWhiteSpaceException"/> class with the specified parameters.
        /// </summary>
        /// <param name="paramName">name of the parameter.</param>
        /// <param name="actualValue">the runtime value of the parameter.</param>
        /// <param name="message">the message in the exception.</param>
        /// <param name="innerException">the <see cref="Exception"/> that caused this exception.</param>
        public ArgumentWhiteSpaceException(string paramName, object actualValue, string message, Exception innerException)
            : base(message, paramName, innerException)
        {
            this.ActualValue = actualValue;
        }

        /// <summary>
        /// Gets the actual value of the argument.
        /// </summary>
        public object ActualValue { get; private set; }
    }
}