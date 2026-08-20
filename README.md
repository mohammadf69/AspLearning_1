# AspLearning_1

A hands-on **ASP.NET Core MVC learning project** built with **.NET 8**, covering controllers, routing, model binding, middleware, Entity Framework Core, logging, error handling, caching, Redis, and dependency injection.

> 🚧 **Status:** Learning / Work in Progress

## 🎯 Purpose

This repository is a practical collection of ASP.NET Core concepts implemented while learning the framework. It is intentionally more experimental than production-oriented, with examples and exercises kept close to the framework features they demonstrate.

## 🛠️ Technology Stack

- **.NET 8 / ASP.NET Core**
- **ASP.NET Core MVC**
- **Entity Framework Core 8**
- **SQL Server**
- **Serilog**
- **ElmahCore**
- **Redis / StackExchange.Redis**
- **Dependency Injection**
- **Custom Model Binding**
- **Custom Middleware**
- **Response Caching / Output Caching**

The main application targets .NET 8 and uses EF Core 8 packages. fileciteturn28file0L2-L2

## 📁 Repository Structure

```text
AspLearning_1
├── AspLearning_1
│   ├── Binder
│   ├── Context
│   ├── Controllers
│   ├── Entites
│   ├── InterFaces
│   ├── MiddelWares
│   ├── Services
│   ├── Migrations
│   └── Dtos
│
├── ControllerCourse
│   ├── Controller
│   ├── Models
│   └── Json
│
└── AspLearning_1.sln
```

The solution currently contains the main `AspLearning_1` web application and a separate `ControllerCourse` project. fileciteturn24file0L2-L2

## 📚 Concepts Covered

### ASP.NET Core MVC

- Controllers and Actions
- Conventional routing
- Attribute routing
- Route constraints
- Model binding
- Custom model binder providers
- Dependency Injection
- Request pipeline

The `ControllerCourse` project is specifically focused on controller/routing fundamentals and maps both controller routes and conventional MVC routes. fileciteturn27file0L2-L2

### Middleware

The main application contains examples of:

- Custom middleware
- Convention-based middleware
- `UseWhen`
- Middleware ordering
- Before/after request processing

### Entity Framework Core

The project uses SQL Server through EF Core and contains a `DbContext` with relationships including:

- One-to-many
- One-to-one
- Many-to-many
- Composite keys
- Cascade delete behavior

These mappings are implemented in `Mycontext`. fileciteturn33file0L2-L2

### Logging & Error Handling

The application uses:

- **Serilog** for application logging
- **ElmahCore** for error logging and inspection

Logs can be written to both the console and rolling log files. fileciteturn29file0L2-L2

### Caching

The project explores:

- ASP.NET Core Response Caching
- Output Caching
- Redis through `StackExchange.Redis`

Redis is currently configured for a local instance at `localhost:6379`. fileciteturn29file0L2-L2

## 🚀 Getting Started

### Prerequisites

Install:

- .NET 8 SDK
- SQL Server
- Redis, if the Redis examples are required

### Clone

```bash
git clone https://github.com/mohammadf69/AspLearning_1.git
cd AspLearning_1
```

### Configure the database

Set the `DefaultConnection` connection string in the application's configuration to match your local SQL Server instance.

### Run

```bash
dotnet restore
dotnet build
dotnet run --project AspLearning_1
```

## ⚠️ Configuration & Security

Connection strings should be treated as environment-specific configuration. Do not commit real database credentials, passwords, API keys, or other secrets to Git.

For local development, prefer **User Secrets**, environment variables, or another secure configuration provider.

## 🗺️ Roadmap

- [x] ASP.NET Core MVC fundamentals
- [x] Controllers and routing
- [x] Custom model binding
- [x] Middleware experiments
- [x] EF Core and SQL Server
- [x] Serilog logging
- [x] ElmahCore error logging
- [x] Redis integration
- [x] Response / Output caching
- [ ] Add automated tests
- [ ] Improve naming and consistency across the learning examples
- [ ] Separate demonstration code from production-style application code
- [ ] Add API examples
- [ ] Add authentication and authorization examples

## 🎓 Learning Notes

This repository is primarily a **learning laboratory**, not a production application. Some examples intentionally demonstrate framework behavior rather than following the architecture that would be preferred in a production system.

That distinction matters: learning how middleware works is useful; shipping a 400-line `Program.cs` containing every experiment ever attempted is not. Humanity has suffered enough. 😐

## 📄 License

This project is currently intended for personal learning and experimentation.
