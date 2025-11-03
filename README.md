# 🧩 Rwt-BackendForBeginners (.NET 10)

A simple **.NET 10 backend project** designed to teach core backend development concepts — from API controllers and data access to services and database integration.

---

## 🚀 How to Run the App

### 🐳 Option 1: Run with Docker (recommended)

Everything is pre-configured — just run one command:

```bash
docker-compose up -d

```

✅ This will:

- Start a **PostgreSQL** database
- Start the **backend API** container
- Automatically connect the app to the database

The API will be available at:

👉 http://localhost:8080

If you also run **pgAdmin**, you can access it at:

👉 http://localhost:5555

(default login: `pgadmin4@pgadmin.org` / `admin`)

#### IMPORTANT!

After you run container for the first time (docker compose) you need to run in the project folder:

```
dotnet ef database update
```

This will update needed tables inside your newly created database. If you want to test existing stuff, open /swagger route and send some requests.

---

### 💻 Option 2: Run locally (without Docker)

If you prefer running it directly with the .NET SDK:

1. Create a file named `appsettings.Development.json` in the project root:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Port=5432;Database=BackendTutorial;Username=postgres;Password=postgres"
     }
   }
   ```

2. Start the backend:

   ```bash
   dotnet run

   ```

---

## 📁 Project Structure Overview

```
BackendForBeginners-Net10-Solution/
│
├── Controllers/           # API endpoints (e.g. UserController.cs)
├── Dtos/                  # Data Transfer Objects for requests/responses
├── Models/                # Database models (e.g. User.cs)
├── Migrations/            # EF Core migration files for database schema
├── Repositories/          # Data access layer (interfaces + implementations)
├── Services/              # Business logic layer
│
├── AppDbContext.cs        # EF Core database context
├── Program.cs             # Application entry point and service setup
├── Dockerfile             # Defines how the app container is built
├── docker-compose.yaml    # Defines how the app and database run together
└── appsettings.json       # Base configuration file

```

---

## 🧠 What You’ll Learn

- How to structure a clean .NET backend project
- How to use **controllers, services, and repositories**
- How to connect to a **PostgreSQL database** with Entity Framework Core
- How to handle **exceptions with middleware**
- How to containerize apps with **Docker & Docker Compose**

---

## 🛠 Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/)
- [Docker & Docker Compose](https://www.docker.com/)
- (Optional) [pgAdmin](https://www.pgadmin.org/) or any PostgreSQL client
