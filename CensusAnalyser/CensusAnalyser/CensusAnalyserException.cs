using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        string message;
        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="_message">The message.</param>
        public CensusAnalyserException(string _message)
        {
            this.message = _message;
        }

        /// <summary>
        /// Gets the get message.
        /// </summary>
        /// <value>
        /// The get message.
        /// </value>
        public string GetMessage { get => message; }
    }
}
