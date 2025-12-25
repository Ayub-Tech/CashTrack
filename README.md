# 💰 CashTrack - Personal Finance Management API

A fullstack application for managing personal finances, including categories, transactions, and users. Built with Clean Architecture principles to demonstrate professional software development practices.

---

## 🛠 Technology Stack

### Backend
- *.NET 8* - Web API
- *C#* - Programming language
- *Entity Framework Core* - ORM
- *SQL Server* - Database
- *FluentValidation* - Input validation
- *Swagger/OpenAPI* - API documentation

### Architecture
- *Clean Architecture* with layered design
- *Repository Pattern* for data access
- *Service Pattern* for business logic
- *Dependency Injection* throughout

---

## 📁 Project Structure

CashTrack/
├── CashTrack.Api/              # API Layer (Controllers, Middleware)
│   ├── Controllers/            # API endpoints
│   ├── Middlewares/           # Global exception handling
│   └── Program.cs             # Application startup
│
├── CashTrack.Application/      # Application Layer (Business Logic)
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Interfaces/            # Service and Repository interfaces
│   ├── Services/              # Business logic implementation
│   └── Validators/            # FluentValidation rules
│
├── CashTrack.Domain/           # Domain Layer (Entities)
│   └── Entities/              # Domain models (Category, Transaction, User)
│
└── CashTrack.Infrastructure/   # Infrastructure Layer (Data Access)
├── Data/                  # DbContext
├── Repositories/          # Repository implementations
└── Migrations/            # EF Core migrations
---

## 🚀 Features

### ✅ Complete CRUD Operations
- *Categories* - Manage spending categories (Food, Transport, etc.)
- *Transactions* - Track income and expenses
- *Users* - User management

### ✅ Data Validation
- Input validation using FluentValidation
- Automatic validation on all endpoints
- Clear error messages

### ✅ Error Handling
- Global exception middleware
- Consistent error responses
- Detailed logging

### ✅ Relationships
- User → Transactions (One-to-Many)
- Category → Transactions (One-to-Many)
- Transaction → User & Category (Many-to-One)

---

## 🗄 Database Schema

### Tables
- *Categories* - id, name
- *Transactions* - id, amount, date, userId, categoryId
- *Users* - id, name, email

### Relationships
- Each Transaction belongs to one User
- Each Transaction belongs to one Category
- Users and Categories can have many Transactions

---

## 🔧 Setup Instructions

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or full SQL Server)
- Visual Studio 2022 or VS Code

### Installation Steps

1. *Clone the repository*
   ```bash
   git clone https://github.com/Ayub-Tech/CashTrack.git
   cd CashTrack
---

✅ CI/CD Status: Automated builds and tests enabled
