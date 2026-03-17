using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.CustomExceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException(Guid bookingId)
            : base($"Booking with ID '{bookingId}' was not found.")
        {
        }
    }
}
