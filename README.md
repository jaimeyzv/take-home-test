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

💡 Notes
Ensure that the backend API is running before accessing the frontend.

If you're using different ports, update the environment configuration accordingly.