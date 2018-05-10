using System;

namespace Bliss.Recruitment.Common.Exceptions
{
    public class BlissException : Exception
    {
        public BlissException(string message)
            : base(message)
        { }

        public BlissException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
