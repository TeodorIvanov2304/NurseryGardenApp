# NurseryGardenApp
Nursery garden store

My final project for the ASP.NET course

**NurseryGardenApp** is a web application built with ASP.NET Core MVC that manages garden-related products, users, and orders. It supports identity and role-based authentication, data seeding, service-oriented architecture, and integrates with external APIs.

---

## 🚀 Tech Stack

- ASP.NET Core 7+
- Entity Framework Core (SQL Server)
- Identity with roles and claims
- Razor Pages & MVC pattern
- JSON-based product seeding
- Dependency Injection
- HTTP Client for external APIs
- MS SQL Server (LocalDB)

---

## 🛠️ Getting Started

### Prerequisites

- .NET 7 SDK
- Visual Studio 2022+
- SQL Server or LocalDB
- Git

### Clone and Run

```bash
git clone https://github.com/yourusername/NurseryGardenApp.git
cd NurseryGardenApp
dotnet restore
dotnet ef database update
dotnet run
