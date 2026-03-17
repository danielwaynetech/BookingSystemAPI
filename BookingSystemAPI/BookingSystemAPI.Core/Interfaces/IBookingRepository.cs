using BookingSystemAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.Interfaces
{
    public interface IBookingRepository
    {
        Task<BookingModel> AddBookingAsync(CreateBookingRequestModel createBooking);
        Task<BookingModel> UpdateBookingAsync(UpdateBookingRequestModel updateBooking);
        Task<BookingModel> DeleteBookingAsync(DeleteBookingRequestModel deleteBooking);
    }
}
