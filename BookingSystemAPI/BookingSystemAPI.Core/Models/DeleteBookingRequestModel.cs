using System.ComponentModel.DataAnnotations;

namespace BookingSystemAPI.Core.Models
{
    public class DeleteBookingRequestModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
