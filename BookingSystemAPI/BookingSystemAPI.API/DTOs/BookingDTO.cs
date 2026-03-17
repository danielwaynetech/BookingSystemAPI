using BookingSystemAPI.Core.Models;

namespace BookingSystemAPI.API.DTOs
{
    /// <summary>
    ///  API Response for a single booking
    /// </summary>
    public record BookingDTO(
        Guid Id,
        string UserEmail,
        string BookTitle,
        string Author,
        DateTime HolidayStartDate,
        DateTime HolidayEndDate,
        bool IsDeleted,
        DateTime? DeletedAt,
        DateTime CreatedAt,
        DateTime UpdatedAt
        )
    {
        public static BookingDTO FromBookingModel(BookingModel b) => new(
            b.Id,
            b.UserEmail,
            b.BookTitle,
            b.Author,
            b.HolidayStartDate,
            b.HolidayEndDate,
            b.IsDeleted,
            b.DeletedAt,
            b.CreatedAt,
            b.UpdatedAt
        );
    }
}
