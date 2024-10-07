# Clean Architecture with CQRS Pattern (NET CORE 8)
This project is a real core base of project that designed clean architecture with CQRS pattern

# Prerequisites
.NET 8 SDK
Visual Studio 2019 or Visual Studio Code
PostgreSQL

## Installation
To Create Migration 
```bash
dotnet ef migrations add init --project "src\BaseApplication\Persistence" --startup-project "src\BaseApplication\Api"
```

To Create Database 
```bash
update-database
```

# Technologies Used
.NET 8
Entity Framework Core
PostgreSQL
Custom Authentication JWT Token (Role Base)
MediatR
AutoMapper
FluentValidation
