using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using BookingSystemAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemAPI.Infrastructure
{
    public class BookingSystemDbContext : DbContext
    {
        public BookingSystemDbContext(DbContextOptions<BookingSystemDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<BookingModel> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // add global query filter to exclude deleted bookings
            modelBuilder.Entity<BookingModel>()
                .HasQueryFilter(b => !b.IsDeleted);
            
            modelBuilder.Entity<BookingModel>()
                .HasIndex(b => b.UserEmail);
        }
    }
}
