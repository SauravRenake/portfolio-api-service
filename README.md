# Portfolio API Service

Backend API for a personal **portfolio website**, built using **ASP.NET Core Web API**, **Entity Framework Core**, and **PostgreSQL**.
This service exposes CRUD APIs to manage profile information that will be consumed by a React frontend.

---

## 🚀 Tech Stack

* **.NET 9 / 10 (ASP.NET Core Web API)**
* **Entity Framework Core**
* **PostgreSQL** (current DB)
* **xUnit** (unit testing)
* **EF Core InMemory** (testing)
* **Swagger / OpenAPI**

> ℹ️ Future plan: Snowflake (read-optimized analytics DB)

---

## 📁 Solution Structure

```
portfolio-api-service
│
├── src
│   ├── Portfolio.Api          # Web API (Startup project)
│   ├── Portfolio.Model        # Entity models
│   ├── Portfolio.Interface    # Service interfaces
│   ├── Portfolio.Service      # Business logic
│   └── Portfolio.Data         # DbContext & EF Core
│
├── test
│   └── Portfolio.Tests        # xUnit tests (Service + Controller)
│
└── Portfolio.sln
```

---

## ⚙️ Prerequisites

Make sure you have the following installed:

* **.NET SDK 9 / 10**
* **PostgreSQL** (running locally)
* **Git**

Check versions:

```bash
dotnet --version
psql --version
```

---

## 🔧 Database Configuration

Update `appsettings.json` in **Portfolio.Api**:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=portfolio_db;Username=postgres;Password=your_password"
  }
}
```

---

## 🗄️ Run Migrations

From solution root:

```bash 
dotnet ef migrations add InitialProfile --project src/Portfolio.Data --startup-project src/Portfolio.Api
```

```bash
dotnet ef database update --project src/Portfolio.Data --startup-project src/Portfolio.Api
```

This will:

* Create database (if not exists)
* Create required tables

---

## ▶️ Run the API

```bash
dotnet run --project src/Portfolio.Api
```

API will be available at:

```
http://localhost:5046
```

Swagger UI:

```
http://localhost:5046/swagger
```

---

## 📌 Available Endpoints (Profile)

| Method | Endpoint          | Description       |
| ------ | ----------------- | ----------------- |
| GET    | /api/profile      | Get all profiles  |
| GET    | /api/profile/{id} | Get profile by ID |
| POST   | /api/profile      | Create profile    |
| PUT    | /api/profile/{id} | Update profile    |
| DELETE | /api/profile/{id} | Delete profile    |

> ID is auto-incremented by the database (starts from 1).

---

## 🧪 Run Tests

Run all tests:

```bash
dotnet test
```

Run only test project:

```bash
dotnet test test/Portfolio.Tests
```

Test setup:

* EF Core InMemory database
* Parallel-safe execution
* No external DB required

---

## 📦 NuGet Packages (Key)

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Npgsql
* Microsoft.EntityFrameworkCore.InMemory
* Swashbuckle.AspNetCore
* xUnit

---

## 📄 Migrations & Git

✔ **Commit migrations** – they are part of schema history
✔ Do NOT commit `bin/` or `obj/`
✔ Connection strings should not contain real passwords

---

## 🎯 Current Scope

* Single Profile CRUD (portfolio owner)
* Clean layered architecture
* Test-first backend

---

## 🔮 Future Enhancements

* DTOs & validation
* Authentication / Authorization
* Projects, Skills, Experience modules
* CI/CD (GitHub Actions)
* Snowflake integration

---

## 👤 Author

**Sonu Renake**
Portfolio Backend Service
---