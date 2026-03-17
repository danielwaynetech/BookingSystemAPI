using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystemAPI.Core.Models
{
    public class BookingModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        // User Email as Id of the person making the booking
        [Required]
        [StringLength(255)]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string BookTitle { get; set; } = string.Empty;
        [Required]
        [StringLength(255)]
        public string Author { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public DateTime HolidayStartDate { get; set; }
        public DateTime HolidayEndDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
