# Sponsorship Management System - Backend API

This is the **Backend API** for the Sponsorship Management System built using **ASP.NET Core Web API (.NET 10)**.  
It provides secure, role-based, workflow-driven APIs for managing sponsorship requests and sponsorship types.

---

## 🚀 Features

- RESTful Web API built with ASP.NET Core
- Sponsorship request workflow:
  - Draft → Pending Manager Approval → Pending Finance Review → Approved / Rejected / Cancelled
- Sponsorship Type management (CRUD)
- Clean architecture with separation of concerns
- Entity Framework Core with PostgreSQL support
- DTO-based communication


---

## 📁 Repository Structure
```
Sponsorship/
├── Sponsorship.Api/               # API / presentation layer (controllers, endpoints)
├── Sponsorship.Application/       # Application logic
│   ├── Services/                  # Business logic
│   └── DTOs/                      # Data Transfer Objects
├── Sponsorship.Domain/            # Domain / core (entities)
├── Sponsorship.Infrastructure/    # Data access, repository implementations, EF Core, DB context
```
**3. Create database**

Run the SQL script located in **Sponsorship.Infrastructure/Data/database_schema.sql**  AND **Sponsorship.Infrastructure/Data/table_data.sql** to create the database tables and insert dummy data.   
