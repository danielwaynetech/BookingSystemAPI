using BookingSystemAPI.Core.Interfaces;
using BookingSystemAPI.Core.Models;
using BookingSystemAPI.Core.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystemAPI.Infrastructure
{
    // Note: Async not fully implemented in this class as this is using inMemory database
    public class BookingSystemRepository : IBookingRepository
    {
        private readonly BookingSystemDbContext _repository;
        public BookingSystemRepository(BookingSystemDbContext repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task<BookingModel> AddBookingAsync(CreateBookingRequestModel createBooking)
        {
            var newBooking = new BookingModel
            {
                Id = Guid.NewGuid(),
                UserEmail = createBooking.UserEmail,
                BookTitle = createBooking.BookTitle,
                Author = createBooking.Author,
                HolidayStartDate = createBooking.HolidayStartDate,
                HolidayEndDate = createBooking.HolidayEndDate
            };

            _repository.Bookings.Add(newBooking);
            _repository.SaveChanges();

            return newBooking;
        }

        public Task<BookingModel> UpdateBookingAsync(UpdateBookingRequestModel updateBooking)
        {
            var existingBooking = _repository.Bookings.FirstOrDefault(updateBooking.Id)
                ?? throw new BookingNotFoundException(updateBooking.Id);

            existingBooking.BookTitle = updateBooking.BookTitle;
            existingBooking.Author = updateBooking.Author;
            existingBooking.HolidayStartDate = updateBooking.HolidayStartDate;
            existingBooking.HolidayEndDate = updateBooking.HolidayEndDate;
            existingBooking.UpdatedAt = DateTime.UtcNow;

            _repository.Bookings.Update(existingBooking);
            _repository.SaveChanges();

            return existingBooking;
        }

        public Task<BookingModel> DeleteBookingAsync(DeleteBookingRequestModel deleteBooking)
        {
            var existingBooking = _repository.Bookings.FirstOrDefault(deleteBooking.Id)
                ?? throw new BookingNotFoundException(deleteBooking.Id);

            if (!existingBooking.IsDeleted)
            {
                existingBooking.IsDeleted = true;

                _repository.Bookings.Update(existingBooking);
                _repository.SaveChanges();
            }

            return existingBooking;
        }
    }
}
