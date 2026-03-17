using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.CustomExceptions
{
    public class BookingValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
