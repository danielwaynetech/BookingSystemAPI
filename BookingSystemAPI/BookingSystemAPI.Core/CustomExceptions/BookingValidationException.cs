using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.CustomExceptions
{
    public class BookingValidationException : Exception
    {
        public BookingValidationException(string message)
            : base(message)
        {
        }
    }
}
