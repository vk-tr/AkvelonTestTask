using System;

namespace AkvelonTestTask.Exceptions
{
    /// <summary>
    /// Custom Validation Exception
    /// </summary>
    public class ValidationException : Exception
    {
        public ValidationException(string message): base(message)
        {
        }
    }
}