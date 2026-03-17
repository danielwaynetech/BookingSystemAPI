using System.ComponentModel.DataAnnotations;

namespace BookingSystemAPI.Core.Models
{
    public class UpdateBookingRequestModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(500)]
        public string BookTitle { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string Author { get; set; } = string.Empty;  
        [Required]
        public DateTime HolidayStartDate { get; set; }
        [Required]
        public DateTime HolidayEndDate { get; set; }
    }
}
