using System.ComponentModel.DataAnnotations;

namespace BookingSystemAPI.Core.Models
{
    public class CreateBookingRequestModel
    {
        [Required]
        [StringLength(255)]
        [EmailAddress(ErrorMessage="Invalid email format.")]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string BookTitle { get; set; } = string.Empty;
        [StringLength(255)]
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public DateTime HolidayStartDate { get; set; }
        [Required]
        public DateTime HolidayEndDate { get; set; }
    }
}
