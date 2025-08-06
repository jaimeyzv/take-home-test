# 🧩 Project Setup Guide

Follow these steps to set up and run the application (Database + .NET API + Angular Frontend).

---

## ✅ 1. Database – SQL Server

- Go to the project root and locate the script:  
  `database-objects-creation.sql`

- The easiest way to run it is via **SQL Server Management Studio (SSMS)**:
  1. Open SSMS.
  2. Open the `.sql` file.
  3. Execute the script.

- ⚠️ This script will create the database with the name expected by the Web API.  
  **Do not modify anything** in the script.

---

## ✅ 2. Backend – .NET Core Web API

- In **Visual Studio**, set the project `Fundo.Applications.WebApi` as the **Startup Project**.
- Run the application (`F5` or use the green "Run" button).
- ⚠️ When the Web API runs for the first time, it will execute the seed method and load initial data into the database.
---

## ✅ 3. Frontend – Angular

- Open a terminal in the frontend project directory and install dependencies:

  ```bash
  npm install
Start the development server:

bash
Copiar
Editar
npm run start
The Angular app will be served on a local port (e.g. http://localhost:4200).

Open the browser and navigate to that address to use the UI.

---
## 💡 Notes
Ensure that the backend API is running before accessing the frontend.

If you're using different ports, update the environment configuration accordingly.

---

## 📁 Project Structure

take-home-test/
├── .github/
│   └── workflows/
├── backend/
│   └── src/
│       ├── Core/
│       │   ├── Fundo.Applications.Application/
│       │   │   ├── Services/
│       │   │   └── UseCases/
│       │   │       ├── CreateLoan/
│       │   │       ├── GetLoanById/
│       │   │       ├── GetLoanList/
│       │   │       └── PayLoan/
│       │   └── Fundo.Applications.Domain/
│       │       ├── Entities/
│       │       ├── Interfaces/
│       │       └── ValueObjects/
│       ├── Infrastructure/
│       │   └── Fundo.Applications.Infrastructure/
│       │       └── Persistance/
│       │           ├── Context/
│       │           ├── Entities/
│       │           ├── Mappers/
│       │           ├── Repositories/
│       │           └── Services/
│       └── Presentation/
│           ├── Fundo.Applications.WebApi/
│           │   ├── Controllers/
│           │   └── Extensions/
│           └── Fundo.Services.Tests/
│               ├── Integration/
│               │   └── Fundo.Applications.WebApi/
│               │       └── Controllers/
│               └── Unit/
│                   └── Fundo.Applications.WebApi/
│                       └── Controllers/
├── frontend/
│   ├── public/
│   └── src/
│       └── app/
│           └── features/
│               └── loans/
│                   ├── components/
│                   │   ├── loan-create/
│                   │   ├── loan-list/
│                   │   └── loan-pay/
│                   ├── models/
│                   └── services/
├── Dockerfile
├── docker-compose.yml
└── README.md


## 🛠️ Implementation Approach

### 🔹 Backend

The backend was built using **Clean Architecture principles**, placing a strong emphasis on separating concerns and encapsulating business rules:

- **Domain-Driven Design (DDD)**: Core domain logic is isolated in the `Domain` layer to ensure high cohesion and maintainability.
- **MediatR**: Utilized to decouple controllers from application logic, allowing clear orchestration of commands and queries within use cases.
- **Repository & Unit of Work Patterns**: Used to abstract and centralize data access logic, supporting better testability and transaction management.
- **Database Seeding**: Included a seed mechanism to populate initial data for development and testing purposes.
- **Extension Methods for Configuration**: Applied to maintain modular startup configurations, keeping `Program.cs` and `Startup.cs` clean and organized.
- **RESTful API Design**: Endpoints follow standard HTTP semantics for clarity and scalability.
- **Testing**:
  - **xUnit** for both **unit** and **integration** tests.
  - **Unit Tests** for isolated components and logic validation.
  - **Integration Tests** to validate full scenarios with real data access.
  - Covered **happy paths** and **exceptional scenarios** in both testing types.

### 🔹 Frontend

The frontend was implemented using Angular 17 with a focus on modularity and responsive design:

- **Tailwind CSS**: Adopted for responsive, utility-first styling.
- **Feature-Based Architecture**: Ensures maintainability by isolating concerns and functionality per domain feature.

## 🚧 Challenges Faced

1. **Initial Complexity with Clean Architecture**  
   Adapting Clean Architecture from scratch required careful restructuring, especially to ensure responsibilities were assigned correctly across layers.

2. **Shared Seed Data for Integration Tests**  
   I aimed to unify seed data for both application bootstrapping and integration tests, but was unable to fully abstract and reuse the same seed logic across both contexts.

3. **Tailwind CSS Setup with Angular**  
   Faced compatibility issues with the latest Tailwind CSS version and Angular dependencies. Despite attempts, I couldn't get Tailwind running successfully within the current setup.

## 🔄 Future Improvements

Given more time, I would:

- Complete the shared seeding utility to eliminate duplication and improve test reliability.
- Resolve Tailwind + Angular integration for better styling consistency.
- Add API documentation via Swagger/OpenAPI.
- Expand test coverage for edge cases and error handling.