# FSAD_ASSIGNMENT
# School Vaccination Portal

A full-stack web application built to manage and track student vaccinations in schools.


##  Technologies Used

| Layer     | Technology                        |
|-----------|-----------------------------------|
| Frontend  | Angular 18 (Standalone API)       |
| UI Design | Angular Material                  |
| Backend   | ASP.NET Core Web API (.NET 8)     |
| Database  | PostgreSQL + EF Core (Npgsql)     |
| Auth      | JWT Bearer Authentication         |
| Tools     | Swagger, Visual Studio   |

---

##  Features

-  JWT-based login and session handling
-  Dashboard with quick access to drives and analytics
-  Student management (Add, Edit, Delete)
-  Vaccination drive scheduling with class targeting
-  Duplicate drive validation by date & vaccine
-  Backend validations & clean DTO separation
-  Vaccination tracking and reporting 

---

##  How to Run

###  Backend (ASP.NET Core API)

1. Open the solution in **Visual Studio 2022**
2. Update `appsettings.json` with your PostgreSQL connection string


Access Swagger at: https://localhost:<port>/swagger

Default user (for login): coordinator / password123

Frontend (Angular 18)
Navigate to the Angular project folder:

cd frontend
Install dependencies:

npm install
Start the app:

ng serve
Visit http://localhost:4200 in your browser

API Endpoints (Sample)
POST /auth/login

GET /students

POST /vaccinationdrive

GET /vaccinationdrive/{id}

Full documentation available in Swagger 

Database Schema
Users: Authentication

Students: Class, name, section, guardian

Vaccines: Master list

VaccinationDrives: References Vaccine, applicable classes (stored as comma-separated)

