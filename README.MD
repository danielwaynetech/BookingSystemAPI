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
A sample request body is available below the 'Test Request' button at each endpoint.