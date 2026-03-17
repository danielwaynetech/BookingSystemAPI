using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.Models
{
    public class BookingModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
