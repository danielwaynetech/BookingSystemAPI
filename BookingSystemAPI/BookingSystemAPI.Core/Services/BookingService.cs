using BookingSystemAPI.Core.CustomExceptions;
using BookingSystemAPI.Core.Interfaces;
using BookingSystemAPI.Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<BookingModel> CreateBookingAsync(CreateBookingRequestModel createBooking)
        {
            ValidateCreateBookingRequest(createBooking);

            return await _repository.AddBookingAsync(createBooking);
        }

        public async Task<BookingModel> UpdateBookingAsync(UpdateBookingRequestModel updateBooking)
        {
            ValidateUpdateBookingRequest(updateBooking);

            return await _repository.UpdateBookingAsync(updateBooking);
        }

        public async Task<BookingModel> DeleteBookingAsync(DeleteBookingRequestModel deleteBooking)
        {
            return await _repository.DeleteBookingAsync(deleteBooking);
        }

        #region Helpers
        private static void ValidateCreateBookingRequest(CreateBookingRequestModel createBooking)
        {
            if (string.IsNullOrWhiteSpace(createBooking.UserEmail))
            {
                throw new BookingValidationException("UserEmail is required.");
            }
            if (string.IsNullOrWhiteSpace(createBooking.Author))
            {
                throw new BookingValidationException("Author is required.");
            }
            if (string.IsNullOrWhiteSpace(createBooking.BookTitle))
            {
                throw new BookingValidationException("Book Title is required.");
            }
            if (createBooking.HolidayEndDate < createBooking.HolidayStartDate)
            {
                throw new BookingValidationException("Holiday End Date cannot precede Holiday Start Date.");
            }
        }

        private static void ValidateUpdateBookingRequest(UpdateBookingRequestModel updateBooking)
        {
            if (string.IsNullOrWhiteSpace(updateBooking.Author))
            {
                throw new BookingValidationException("Author is required.");
            }
            if (string.IsNullOrWhiteSpace(updateBooking.BookTitle))
            {
                throw new BookingValidationException("Book Title is required.");
            }
            if (updateBooking.HolidayEndDate < updateBooking.HolidayStartDate)
            {
                throw new BookingValidationException("Holiday End Date cannot precede Holiday Start Date.");
            }
        }
        #endregion
    }
}
