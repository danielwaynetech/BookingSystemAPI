using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.Models
{
    public class CreateBookingRequestModel
    {
        public string UserEmail { get; set; } = string.Empty;
        public string BookTitle { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
    }
}
