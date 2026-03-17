# Booking System API

A backend booking system API for creating, updating and (soft) deleting booking requests for books.

**Stack:** .NET 10 API * EF InMemory DB * OpenAPI / Scalar

---

## Prerequisites

- .NET 10 SDK installed
- Visual Studio 2022 or VS Code

## Start

### 1. Clone / unzip the project

```bash
cd BookingSystemAPI
```

### 2. Start the API
```bash
dotnet build

cd BookingSystemAPI.API

dotnet run
```

API will be available at: `https://localhost:7258/scalar/`

## API Endpoints

All endpoints are public (no authentication implemented)

post
/api/BookingSystem/create
put
/api/BookingSystem/update
delete
/api/BookingSystem/delete

## Testing Endpoints

Once the API is running, the endpoints will be testable at https://localhost:7258/scalar/

## Project Structure

¦   BookingSystemAPI.slnx
¦   
+---BookingSystemAPI.API
¦   ¦   appsettings.Development.json
¦   ¦   appsettings.json
¦   ¦   BookingSystemAPI.API.csproj
¦   ¦   BookingSystemAPI.API.csproj.user
¦   ¦   BookingSystemAPI.API.http
¦   ¦   Program.cs
¦   ¦   
¦   ¦               
¦   +---Controllers
¦   ¦       BookingSystemController.cs
¦   ¦       
¦   +---DTOs
¦   ¦       BookingDTO.cs   
+---BookingSystemAPI.Core
¦   ¦               
¦   +---CustomExceptions
¦   ¦       BookingNotFoundException.cs
¦   ¦       BookingValidationException.cs
¦   ¦       
¦   +---Interfaces
¦   ¦       IBookingRepository.cs
¦   ¦       IBookingService.cs
¦   ¦       
¦   +---Models
¦   ¦       BookingModel.cs
¦   ¦       CreateBookingRequestModel.cs
¦   ¦       DeleteBookingRequestModel.cs
¦   ¦       UpdateBookingRequestModel.cs
¦   ¦                   
¦   +---Services
¦           BookingService.cs
¦           
+---BookingSystemAPI.Infrastructure
    ¦   BookingSystemAPI.Infrastructure.csproj
    ¦   BookingSystemDbContext.cs
    ¦   BookingSystemRepository.cs