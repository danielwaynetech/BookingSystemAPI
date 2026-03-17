using BookingSystemAPI.Core.Interfaces;
using BookingSystemAPI.Core.Services;
using BookingSystemAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add InMemory db
builder.Services.AddDbContext<BookingSystemDbContext>(options =>
    options.UseInMemoryDatabase("BookingSystemDb"));

// Register services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingSystemRepository>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Booking System API");
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
