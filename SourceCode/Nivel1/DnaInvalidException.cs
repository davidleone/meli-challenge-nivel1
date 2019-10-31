using System;

namespace Nivel1
{
    /// <summary>
    /// The exception that is thrown when the dna chain provided to a method is not valid.
    /// </summary>
    public class DnaInvalidException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the DnaInvalidException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public DnaInvalidException(string message) : base(message) { }
    }
}
